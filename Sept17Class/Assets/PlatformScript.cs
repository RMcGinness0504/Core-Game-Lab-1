using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    public float speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().color = Random.ColorHSV(0.0f, 1.0f, 1f, 1f, 0.5f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - speed * Time.deltaTime);

        if (transform.position.y < -5.5)
        {
            Destroy(gameObject);
        }
    }
}
