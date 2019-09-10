using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forces : MonoBehaviour
{
    Rigidbody2D rigidB;
    public float forceAmount;

    // Start is called before the first frame update
    void Start()
    {
        rigidB = GetComponent<Rigidbody2D>();
        rigidB.AddForce(new Vector2(Random.Range(-1.0f, 1.0f), 1) * forceAmount, ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Square (1)")
        {
            collision.gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0);
        }
    }
}