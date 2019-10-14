using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookScript : MonoBehaviour
{
	public GameObject otherBookObject;
    GameObject mainObject;

    private void Start()
    {
        mainObject = GameObject.Find("submit");    
    }

    private void OnMouseDown()
    {
        if (!mainObject.GetComponent<MainScript>().frozen)
        {
            otherBookObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
