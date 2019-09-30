using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfileScript : MonoBehaviour
{
    public GameObject picObject;
    GameObject textObject;
    GameObject textObject2;
    GameObject textObject3;
    public GameObject canvasObject;
    GameObject buttonObject;
    GameObject buttonMatchObject;
    GameObject mainScreen;
    public bool dismissing = false;
    public bool goodDismissing = false;

    GameObject main;

    public string name;
    public Sprite pic;
    public string location;
    public string bio;

    // Start is called before the first frame update
    void Start()
    {
        mainScreen = GameObject.Find("mainScreen");

        picObject = this.transform.GetChild(0).gameObject;
        canvasObject = picObject.transform.GetChild(0).gameObject;
        textObject = canvasObject.transform.GetChild(0).gameObject;
        textObject.GetComponent<Text>().text = name;
        textObject2 = canvasObject.transform.GetChild(2).gameObject;
        textObject2.GetComponent<Text>().text = location;
        textObject3 = canvasObject.transform.GetChild(3).gameObject;
        textObject3.GetComponent<Text>().text = bio;
        buttonObject = canvasObject.transform.GetChild(1).gameObject;
        buttonMatchObject = canvasObject.transform.GetChild(4).gameObject;
        buttonObject.GetComponent<Button>().onClick.AddListener(mainScreen.GetComponent<MainController>().generateProfile);
        buttonMatchObject.GetComponent<Button>().onClick.AddListener(mainScreen.GetComponent<MainController>().matchProfile);
        picObject.GetComponent<SpriteRenderer>().sprite = pic;
    }

    // Update is called once per frame
    void Update()
    {
        if (dismissing)
        {
            buttonObject.GetComponent<Button>().interactable = false;
            canvasObject.GetComponent<Canvas>().sortingOrder = 5;
            picObject.GetComponent<SpriteRenderer>().sortingOrder = 5;

            transform.position = new Vector2(transform.position.x - 20 * Time.deltaTime, transform.position.y);
            if (transform.position.x <= -8)
            {
                mainScreen.GetComponent<MainController>().noDismissing = true;
                Destroy(gameObject);
            }
        } else if (goodDismissing)
        {
            buttonObject.GetComponent<Button>().interactable = false;
            canvasObject.GetComponent<Canvas>().sortingOrder = 5;
            picObject.GetComponent<SpriteRenderer>().sortingOrder = 5;

            transform.position = new Vector2(transform.position.x + 20 * Time.deltaTime, transform.position.y);
            if (transform.position.x >= 8)
            {
                Destroy(gameObject);
            }
        }
    }
}
