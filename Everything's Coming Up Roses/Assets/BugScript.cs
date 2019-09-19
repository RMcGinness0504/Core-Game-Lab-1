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

    public Sprite[] parts = new Sprite[4];
    public GameObject piece;

    // Start is called before the first frame update
    void Start()
    {
        rose = GameObject.FindGameObjectWithTag("rose");

        goalX = 0;
        goalY = 0;

        speedX = goalX + transform.position.x;
        speedY = goalY + transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        this.transform.position = new Vector2(transform.position.x - (speedX/timer * Time.deltaTime), transform.position.y - (speedY/timer * Time.deltaTime));
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
            } else
            {
                rose.GetComponent<RoseController>().combo = 0;
            }
        Destroy(gameObject);
        }
    }
}
