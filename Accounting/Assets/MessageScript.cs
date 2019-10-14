using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageScript : MonoBehaviour
{
    public GameObject mainObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mainObject.GetComponent<MainScript>().frozen)
        {
            if (transform.position.y > 0)
            {
                transform.position = new Vector2(0, transform.position.y - 4 * Time.deltaTime);
            }
        } else
        {
            if (transform.position.y < 5.5)
            {
                transform.position = new Vector2(0, transform.position.y + 4 * Time.deltaTime);
            }
        }
    }

    private void OnMouseDown()
    {
        if (transform.position.y <= 0)
        {
            mainObject.GetComponent<MainScript>().frozen = false;
            mainObject.GetComponent<MainScript>().createFile();
        }
    }
}
