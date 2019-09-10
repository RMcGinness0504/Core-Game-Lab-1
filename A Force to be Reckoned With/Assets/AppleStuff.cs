using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleStuff : MonoBehaviour
{
    public Sprite greenSprite;

    public bool safe = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "ground" || collision.gameObject.tag == "apple")
        {
            safe = true;
            GetComponent<SpriteRenderer>().sprite = greenSprite;
        }
    }
}
