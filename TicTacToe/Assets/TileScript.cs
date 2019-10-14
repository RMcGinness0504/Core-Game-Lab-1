using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{
	public bool isX;
	public Sprite xSprite;
	public Sprite oSprite;
	Color xColor = new Color(1.0f,0.1f,0.1f);
	Color oColor = new Color(0.1f,0.1f,1f);

	// Start is called before the first frame update
	void Start()
    {
        if (isX)
        {
            GetComponent<SpriteRenderer>().sprite = xSprite;
            GetComponent<SpriteRenderer>().color = xColor;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = oSprite;
            GetComponent<SpriteRenderer>().color = oColor;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
