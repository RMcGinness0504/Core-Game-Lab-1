using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetControl : MonoBehaviour
{
    float speed = 7;

    public float netBounds = 3.02f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.identity;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (transform.position.x > -1 * netBounds)
            {
                transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
            }
            transform.rotation = Quaternion.Euler(0, 0, 4);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            if (transform.position.x < netBounds)
            {
                transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
            }
            transform.rotation = Quaternion.Euler(0, 0, -4);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bird")
        {
            GetComponent<AudioSource>().Play();
        }
    }
}