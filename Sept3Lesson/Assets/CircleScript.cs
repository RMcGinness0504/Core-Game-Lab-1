using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleScript : MonoBehaviour
{
    Vector2 vec;
    Rigidbody2D rb;

    float mouseX;
    float mouseY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            vec = Input.mousePosition;
            vec = Camera.main.ScreenToWorldPoint(vec);
            rb.AddForce(new Vector2(vec.x - transform.position.x,vec.y - transform.position.y), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
    }
}
