using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	public float speed;

	public GameObject circle;

	public Sprite[] sprites;

	private float posx;

	// Start is called before the first frame update
	void Start()
    {
		sprites = Resources.LoadAll<Sprite>("poopCrab");

		speed = 5;
		transform.position = new Vector2(0, 5);
		GetComponent<SpriteRenderer>().sprite = sprites[0];
	}

    // Update is called once per frame
    void Update()
    {
		//spriteImage = Resources.Load("square.png") as Sprite;
		transform.Translate(new Vector2(0, (-1 * Time.deltaTime*speed)));

		//posx = Mathf.Sin(Time.time);
		//circle.transform.position = new Vector2(posx, 0);
	}
}
