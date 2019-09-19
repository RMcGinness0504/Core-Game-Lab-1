using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedController : MonoBehaviour
{
    GameObject rose;

    // Start is called before the first frame update
    void Start()
    {
        rose = GameObject.FindGameObjectWithTag("rose");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * 10);
        if (transform.position.x > 8 || transform.position.x < -8 || transform.position.y > 5.5 || transform.position.y < -5.5)
        {
            Destroy(gameObject);
        }
    }
}
