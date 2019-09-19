using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    float timer = 0;
    static float timerMax = 1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        transform.Translate(Vector2.up * Time.deltaTime * 10f);

        if(timer >= timerMax)
        {
            Destroy(gameObject);
        }
    }
}
