using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class natuScript : MonoBehaviour
{
    GameObject refObj;
    bool willDestroy = false;
    float destroyTimer = 2.5f;

    public Sprite uncookedChickenSprite;
    public Sprite featherSprite;

    public GameObject bodyPartPrefab;

    void killBird()
    {
        refObj.GetComponent<GameControllerScript>().birdsKilled++;
        GetComponents<AudioSource>()[1].Play();
        refObj.GetComponent<GameControllerScript>().updateUI();
        willDestroy = true;
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        int ranNum = Random.Range(3, 7);
        for (int i = 0; i <= ranNum;i++)
        {
            GameObject f = Instantiate(bodyPartPrefab, new Vector2(transform.position.x + Random.Range(-0.6f,0.6f), transform.position.y + Random.Range(0f, 0.6f)), Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 360))));
            if (i == 0)
            {
                f.GetComponent<SpriteRenderer>().sprite = uncookedChickenSprite;
                f.transform.position = this.transform.position;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        refObj = GameObject.Find("GameObject").gameObject;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, Random.Range(0,360)));
    }

    // Update is called once per frame
    void Update()
    {
        if (willDestroy)
        {
            transform.position = new Vector2(-9, -9);
            destroyTimer -= Time.deltaTime;
            if(destroyTimer <= 0)
            {
                Destroy(gameObject);
            }
        } else
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, transform.rotation.eulerAngles.z + Time.deltaTime * 180));
            if (transform.position.y < -4)
            {
                killBird();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "kill")
        {
            killBird();
        } else if (collision.gameObject.tag == "save")
        {
            refObj.GetComponent<GameControllerScript>().savedBirds++;
            GetComponents<AudioSource>()[2].Play();
            refObj.GetComponent<GameControllerScript>().updateUI();
            willDestroy = true;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        }
    }
}