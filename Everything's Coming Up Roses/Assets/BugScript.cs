using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BugScript : MonoBehaviour
{
    float goalX;
    float goalY;
    float speedX;
    float speedY;
    float timer = 5;
    public GameObject rose;
    public GameObject rose2;
    public GameObject rose3;
    public GameObject stem;

    public Sprite[] parts = new Sprite[4];
    public GameObject piece;

    // Start is called before the first frame update
    void Start()
    {
        rose = GameObject.FindGameObjectWithTag("rose");
        rose2 = GameObject.FindGameObjectWithTag("rose2");
        rose3 = GameObject.FindGameObjectWithTag("rose3");
        stem = GameObject.FindGameObjectWithTag("stem");

        goalX = 0;
        goalY = 0;

        if (transform.position.x > 0)
        {
            if (rose2.GetComponent<RoseController>().roseHealth > 0)
            {
                goalX = 2.7f;
                goalY = -2;
            } else if (rose3.GetComponent<RoseController>().roseHealth > 0)
            {
                goalX = -2.7f;
                goalY = -2;
            }
        } else
        {
            if (rose3.GetComponent<RoseController>().roseHealth > 0)
            {
                goalX = -2.7f;
                goalY = -2;
            }
            else if (rose2.GetComponent<RoseController>().roseHealth > 0)
            {
                goalX = 2.7f;
                goalY = -2;
            }
        }

        speedX = goalX + transform.position.x;
        speedY = goalY + transform.position.y;

        if (transform.position.x < 0)
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (goalX < -0.5f && rose3.GetComponent<RoseController>().roseHealth < 0 || goalX > 0.5f && rose2.GetComponent<RoseController>().roseHealth < 0)
        {
            goalX = 0;
            goalY = 0;
        }

        if (rose.GetComponent<RoseController>().roseHealth > 0)
        {
            timer -= Time.deltaTime;

            if (goalX > transform.position.x)
            {
                this.transform.position = new Vector2(transform.position.x + 3 * Time.deltaTime, transform.position.y);
            }
            else if(goalX < transform.position.x)
            {
                this.transform.position = new Vector2(transform.position.x - 3 * Time.deltaTime, transform.position.y);
            }

            if (goalY > transform.position.y)
            {
                this.transform.position = new Vector2(transform.position.x, transform.position.y + 3 * Time.deltaTime);
            } else if (goalY < transform.position.y)
            {
                this.transform.position = new Vector2(transform.position.x, transform.position.y - 3*Time.deltaTime);
            }


        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "bug" && collision.gameObject.tag != "piece")
        {
            for (int i = 0; i < 4; i++)
            {
                GameObject p = Instantiate(piece, new Vector2(transform.position.x + UnityEngine.Random.Range(-0.7f, 0.7f), transform.position.y + UnityEngine.Random.Range(-0.7f, 0.3f)), Quaternion.identity);
                p.GetComponent<SpriteRenderer>().sprite = parts[i];
            }
            if (collision.gameObject.tag == "seed")
            {
                rose.GetComponent<RoseController>().score += 100 + rose.GetComponent<RoseController>().combo * 50;
                rose.GetComponent<RoseController>().combo += 1;
                collision.gameObject.GetComponent<SeedController>().seedHealth--;
            } else
            {
                rose.GetComponent<RoseController>().bugTimerMax = rose.GetComponent<RoseController>().bugTimerMax * 1.15f;
                rose.GetComponent<RoseController>().combo = 0;
            }
        stem.GetComponent<AudioSource>().Play();
        Destroy(gameObject);
        }
    }
}
