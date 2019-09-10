using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewtonMove : MonoBehaviour
{
    Animator animateControl;

    public static float hurtTimerMax = 0.7f;
    public float hurtTimer = 0.0f;

    public static float appleTimerMax = 1.0f;
    public float appleTimer = 0.0f;


    public bool fadingOut = false;
    public float alpha = 1.0f;
    bool goingToLose = false;

    public GameObject black;

    public int health = 3;
    public int applesCollected = 0;
    public GameObject uiApple;
    public GameObject cam;
    public GameObject king;
    public GameObject applePrefab;
    public GameObject pApple;

    public AudioSource soundFX;

    public AudioClip winSound;

    public Rigidbody2D rb;

    public AudioSource soundSource;

    public List<GameObject> pApples = new List<GameObject>();

    public GameObject[] coats = new GameObject[3];

    public GameObject[] bgElements = new GameObject[8];

    public Text appleText;

    public void createPlayerApple(float forceMin, float forceMax)
    {
        pApple = Instantiate(applePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        rb = pApple.GetComponent<Rigidbody2D>();
        rb.AddTorque(Random.Range(-5.0f, 5.0f));
        rb.AddForce(new Vector2(Random.Range(forceMin, forceMax), 17), ForceMode2D.Impulse);
        pApples.Add(pApple);
        applesCollected--;
        appleText.text = "x" + applesCollected;
        appleTimer = appleTimerMax;
    }

    // Start is called before the first frame update
    void Start()
    {
        animateControl = GetComponent<Animator>();
        soundFX = uiApple.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fadingOut && !soundSource.isPlaying)
        {
            Debug.Log(alpha);
            alpha = alpha + (float)(0.6 * Time.deltaTime);
            if (alpha >= 1)
            {
                alpha = 1.0f;
                fadingOut = false;
                if (goingToLose)
                {
                    SceneManager.LoadScene("lose", LoadSceneMode.Single);
                }
                else
                {
                    SceneManager.LoadScene("title", LoadSceneMode.Single);
                }
            }
        }
        else
        {
            alpha = alpha - (float)(0.6 * Time.deltaTime);
            if (alpha <= 0)
            {
                alpha = 0.0f;
            }
        }


        black.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, alpha);

        appleTimer = appleTimer - Time.deltaTime;

        if (king.GetComponent<kingControl>().kingHealth <= 0)
        {
            cam.GetComponent<AudioSource>().Stop();
        }

        if (hurtTimer <= 0 && health > 0 && king.GetComponent<kingControl>().kingHealth > 0 && alpha <= 0)
        {
            if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -6)
            {
                if (animateControl.GetInteger("state") != 1)
                {
                    animateControl.SetInteger("state", 1);
                }
                transform.position = new Vector2(transform.position.x - Time.deltaTime * 2, transform.position.y);
            }
            else if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < 6)
            {
                if (animateControl.GetInteger("state") != 0)
                {
                    animateControl.SetInteger("state", 0);
                }
                transform.position = new Vector2(transform.position.x + Time.deltaTime * 2, transform.position.y);
            }
            else if (animateControl.GetInteger("state") == 0)
            {
                animateControl.SetInteger("state", 4);
            }
            else if (animateControl.GetInteger("state") == 1)
            {
                animateControl.SetInteger("state", 5);
            }

            if(applesCollected > 0 && appleTimer <= 0)
            {
                if (Input.GetKey(KeyCode.Q))
                {
                    createPlayerApple(-15.0f, -5.0f);
                }
                else if (Input.GetKey(KeyCode.W))
                {
                    createPlayerApple(-5.0f, 5.0f);
                }
                else if (Input.GetKey(KeyCode.E))
                {
                    createPlayerApple(5.0f, 15.0f);
                }
            }
        } else if (king.transform.position.y < -35)
        {
            fadingOut = true;
            goingToLose = false;
        }
        else if (king.GetComponent<kingControl>().kingHealth <= 0 && animateControl.GetInteger("state") <= 7)
        {
            if (animateControl.GetInteger("state") == 0)
            {
                animateControl.SetInteger("state", 4);
            }
            else if (animateControl.GetInteger("state") == 1)
            {
                animateControl.SetInteger("state", 5);
            }

            if (king.transform.position.y < -4)
            {
                animateControl.SetInteger("state", 8);

                soundSource.clip = winSound;
                soundSource.Play();
            }
    } else if (king.GetComponent<kingControl>().kingHealth > 0)
        {
            if (animateControl.GetInteger("state") != 3)
            {
                hurtTimer = hurtTimer - Time.deltaTime;
            }
            if (hurtTimer <= 0 && health <= 0)
            {
                animateControl.SetInteger("state", 3);
                hurtTimer = 9;
                soundSource.Play();
                fadingOut = true;
                goingToLose = true;
            } else if (hurtTimer <= 0)
            {
                animateControl.SetInteger("state", 4);
            }
        }

        for (int i = pApples.Count - 1; i >= 0; i--)
        {
            if (pApples[i].transform.position.y > 5.4)
            {
                Destroy(pApples[i]);
                pApples.Remove(pApples[i]);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "apple" && hurtTimer <= 0 && king.GetComponent<kingControl>().kingHealth > 0)
        {
            if (collision.gameObject.GetComponent<AppleStuff>().safe)
            {
                Destroy(collision.gameObject);
                applesCollected++;
                appleText.text = "x" + applesCollected;
            }
            else
            {
                animateControl.SetInteger("state", 2);
                hurtTimer = hurtTimerMax;
                health--;
                soundFX.Play();
                coats[health].SetActive(false);
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-2.0f, -0.5f), 2), ForceMode2D.Impulse);
                if (health <= 0)
                {
                    for (int i = pApples.Count - 1; i >= 0; i--)
                    {
                        Destroy(pApples[i]);
                        pApples.Remove(pApples[i]);
                    }
                    hurtTimer = 1.1f;
                    animateControl.SetInteger("state", 6);
                    appleText.text = "";
                    uiApple.SetActive(false);
                    cam.GetComponent<AudioSource>().Stop();
                    for (int i = bgElements.Length - 1; i >= 0; i--)
                    {
                        bgElements[i].GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
                    }
                }
            }
        }
    }
}
