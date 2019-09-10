using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kingControl : MonoBehaviour
{
    bool isLeft;

    public GameObject appleToThrow;
    public GameObject apple;
    public GameObject newton;
    public List<GameObject> apples = new List<GameObject>();
    Rigidbody2D rig;

    public int kingHealth = 7;
    public static float damageTimerMax = 1.5f;
    public float damageTimer = 0;
    public float speed = 2.0f;

    public static float appleTimerMax = 3.0f;
    public static float appleTimerMin = 1.0f;
    float appleTimer;
    float angle = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        appleTimer = Random.Range(appleTimerMin, appleTimerMax);

        if (Random.value > 0.5)
        {
            isLeft = true;
        } else
        {
            isLeft = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (newton.GetComponent<NewtonMove>().health <= 0)
        {
            for (int i = apples.Count - 1; i >= 0; i--)
            {
                Destroy(apples[i]);
            }
            GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        } else if (kingHealth <= 0)
        {
            GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
            transform.position = new Vector2(transform.position.x, (float)(transform.position.y - Time.deltaTime * 8));
            angle = angle + 360 * Time.deltaTime;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        else if (newton.GetComponent<NewtonMove>().alpha <= 0)
        {
            if (damageTimer > 0)
            {
                damageTimer = damageTimer - Time.deltaTime;
                if (damageTimer%0.25 > 0.125)
                {
                    GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
                }
                else
                {
                    GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
                }
            }
            else
            {
                GetComponent<SpriteRenderer>().color = new Color(255,255,255,255);
            }

            appleTimer = appleTimer - Time.deltaTime;
            if (appleTimer <= 0)
            {
                apple = Instantiate(appleToThrow, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                rig = apple.GetComponent<Rigidbody2D>();
                rig.AddTorque(Random.Range(-5.0f, 5.0f));
                rig.AddForce(new Vector2(Random.Range(-2.0f, 2.0f), -2), ForceMode2D.Impulse);
                apples.Add(apple);

                appleTimer = Random.Range(appleTimerMin, appleTimerMax);
            }

            if (isLeft)
            {
                transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
                if (transform.position.x <= -4.7)
                {
                    isLeft = false;
                }
            }
            else
            {
                transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
                if (transform.position.x >= 4.7)
                {
                    isLeft = true;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "pApple" && damageTimer <= 0)
        {
            GetComponent<AudioSource>().Play();
            kingHealth--;
            damageTimer = damageTimerMax;
            speed = speed + 0.3f;
        }
    }
}
