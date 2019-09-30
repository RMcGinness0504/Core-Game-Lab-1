using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoseController : MonoBehaviour
{
    public GameObject fade;
    public GameObject seed;
    public GameObject piece;
    public GameObject bugObject;
    public GameObject tip;
    public GameObject bg;
    public GameObject roseL;
    public GameObject roseR;
    public GameObject sign;

    public bool rosesTurn;

    public Sprite pinkPetal;

    public Text scoreText;

    public bool mainRose = false;

    public int combo = 0;
    public int score = 0;

    float bugTimer = 0f;
    public float bugTimerMax = 4.0f;

    public bool fadingToBlack = false;

    public int roseHealth = 5;
    public static float roseInvincibilityTimer = 2.0f;
    float invincible = 0.0f;

    public float alpha = 1.0f;

    // Start is called before the first frame update
    void Start()
    {

		Cursor.visible = false;
        if (!mainRose)
        {
            roseHealth = 4;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (alpha <= 0.0f)
        //{
            invincible = invincible - Time.deltaTime;
            if (!mainRose)
            {
            }

            if (roseHealth > 0)
            {
                if (invincible > 0 && invincible % 0.5 > 0.25)
                {
                    GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                }
                else
                {
                    GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                }
            }
        //}

        if (mainRose)
        {
            scoreText.text = "SCORE " + score.ToString("D6");

            if (fadingToBlack)
            {
                alpha = (float)(alpha + Time.deltaTime * 0.3);
                if (alpha >= 1.0f)
                {
                    alpha = 1.0f;
                    fadingToBlack = false;

                    SceneManager.LoadScene("title", LoadSceneMode.Single);
                }
            }
            else
            {
                alpha = (float)(alpha - Time.deltaTime * 0.3);
                if (alpha <= 0.0f)
                {
                    alpha = 0.0f;
                }
            }

            if (sign.transform.position.y > 4.5 && roseL.GetComponent<RoseController>().roseHealth <= 0 && roseR.GetComponent<RoseController>().roseHealth <= 0)
            {
                sign.transform.position = new Vector2(sign.transform.position.x, (float)(sign.transform.position.y - 1.5 * Time.deltaTime));
            }
            fade.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, alpha);

            if (alpha <= 0.0f)
            {
                if (roseHealth <= 0 && !tip.GetComponent<AudioSource>().isPlaying)
                {
                    fadingToBlack = true;
                }

                bugTimer = bugTimer - Time.deltaTime;

                if (Input.GetMouseButtonDown(0) && roseHealth > 0)
                {
                    GameObject s = Instantiate(seed, new Vector3(0, 0, 0), Quaternion.identity);
                    Vector3 mousePos = Input.mousePosition;
                    mousePos.z = 0f;

                    Vector3 objectPos = Camera.main.WorldToScreenPoint(new Vector3(0, 0, 0));
                    mousePos.x = mousePos.x - objectPos.x;
                    mousePos.y = mousePos.y - objectPos.y;

                    float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg - 90;
                    s.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

                    GetComponent<AudioSource>().Play();
                }

                if (bugTimer <= 0 && roseHealth > 0)
                {
                    bugTimer = bugTimerMax;
                    bugTimerMax = bugTimerMax * 0.95f;
                    if (Random.value > 0.5)
                    {
                        Instantiate(bugObject, new Vector2(Random.Range(-8.0f, -11.0f), Random.Range(0.0f, 5.0f)), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(bugObject, new Vector2(Random.Range(8.0f, 11.0f), Random.Range(0.0f, 5.0f)), Quaternion.identity);
                    }
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bug" && invincible <= 0)
        {
            invincible = roseInvincibilityTimer;
            roseHealth--;
            GetComponent<Animator>().SetInteger("health", roseHealth);
            if (roseHealth <= 0 && mainRose)
            {
                bg.GetComponent<AudioSource>().Stop();
                tip.GetComponent<AudioSource>().Play();
            }

            if (roseHealth <= 0)
            {
                GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                transform.position = new Vector2(transform.position.x, -99);
            }

            for (int i = 1;i <= 4;i++)
            {
                GameObject x = Instantiate(piece, new Vector2(transform.position.x + Random.Range(-1.0f, 1.0f), transform.position.y + Random.Range(-1.0f, 1.0f)), Quaternion.identity);
                if (!mainRose)
                {
                    x.GetComponent<SpriteRenderer>().sprite = pinkPetal;
                }
            }
        }
    }
}
