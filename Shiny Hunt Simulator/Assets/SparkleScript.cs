using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkleScript : MonoBehaviour
{
    float xSpeed;
    float ySpeed;
    float angle;

    // Start is called before the first frame update
    void Start()
    {
        angle = Random.Range(0.0f, 360.0f);

        xSpeed = Random.Range(-1.0f, 1.0f);
        if (Random.value > 0.5)
        {
            ySpeed = Random.Range(-1.5f,-0.5f);
        } else
        {
            ySpeed = Random.Range(0.5f,1.5f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2((float)(transform.position.x + (xSpeed * 2.5 * Time.deltaTime)), (float)(transform.position.y + ySpeed * 2.5 * Time.deltaTime));
        angle += 45 * Time.deltaTime;
        xSpeed = xSpeed * 1.025f;
        ySpeed = ySpeed * 1.025f;

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);


        if (transform.position.y < -6 || transform.position.y > 6 || transform.position.x > 7.8 || transform.position.x < -7.8)
        {
            Destroy(gameObject);
        }
    }
}
