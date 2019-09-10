using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    Rigidbody2D rb;
    public float forceAmount;

	public GameObject[] planets = new GameObject[4];
	public Vector3 planetPosition;
	public Vector3 direction;
	float distance;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

		planetPosition = planets[0].transform.position;

		rb.AddForce(Vector2.left * 1, ForceMode2D.Impulse);

        forceAmount = 1;
        distance = Vector3.Distance(planets[0].transform.position, transform.position);
	}

    void Update()
	{
		

        foreach (GameObject planet in planets)
		{
			float distcheck = Vector3.Distance(transform.position, planet.transform.position);
            if (distcheck < distance)
			{
				distance = distcheck;
				planetPosition = planet.transform.position;
			}
		}

		direction = planetPosition - transform.position;
		rb.AddForce(direction * forceAmount);
	}

    private void OnTriggerStay2D(Collider2D collision)
    {

		rb.AddForce(direction * forceAmount);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
