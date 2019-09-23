using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public GameObject ball;
    GameObject mainObj;
    // Start is called before the first frame update
    void Start()
    {
        mainObj = GameObject.FindGameObjectWithTag("main");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -6)
        {
            GameObject newBall = Instantiate(ball, new Vector2(Random.Range(-6.0f, 6.0f), 3f), Quaternion.identity);
            newBall.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);

            newBall.GetComponent<AudioSource>().Play();
            mainObj.GetComponent<MainController>().score = 0;
            newBall.name = "bounce";
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<SpriteRenderer>().color = collision.gameObject.GetComponent<SpriteRenderer>().color;
        mainObj.GetComponent<MainController>().score++;
        mainObj.GetComponent<AudioSource>().Play();
    }
}
