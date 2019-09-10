using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wrapping : MonoBehaviour
{
    public float maxX;
    public float maxY;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= maxX)
        {
            transform.position = new Vector2(-maxX, transform.position.y);
        }

        if (transform.position.x < -maxX)
        {
            transform.position = new Vector2(maxX, transform.position.y);
        }

        if (transform.position.y >= maxY)
        {
            transform.position = new Vector2(transform.position.x, -maxY);
        }

        if (transform.position.y < -maxY)
        {
            transform.position = new Vector2(transform.position.x, maxY);
        }

    }
}
