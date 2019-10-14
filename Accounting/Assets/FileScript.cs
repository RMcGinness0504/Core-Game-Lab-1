using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FileScript : MonoBehaviour
{
    GameObject mainObject;
    public bool dismissing;
    public Sprite cactusSprite;
    public List<string> actions = new List<string>();
    public List<int> values = new List<int>();
    public int[] changedValues;
    string fileActions;
    int totalPoints;

    public Sprite stampG;
    public Sprite stampB;
    public Sprite stampE;
    public Sprite stampM;
    public Sprite stampR;
    public GameObject stampSpot;

    bool cactus = false;
    public int fate;
    public int stamp = 0;

    private void Start()
    {
        mainObject = GameObject.Find("submit");
        if (Random.Range(0,100) > 96)
        {
            cactus = true;
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
            GetComponent<SpriteRenderer>().sprite = cactusSprite;
        }

        List<int> usedValues = new List<int>();

        int r = Random.Range(4, 9);
        int v = Random.Range(0, actions.Count);
        for (int i = 1;i <= r;i++)
        {
            if (usedValues.Count >= values.Count)
            {
                break;
            }

            int z = 0;

            while (usedValues.Contains(v))
            {
                z++;
                if (z > 20)
                {
                    break;
                }
                v = Random.Range(0, actions.Count);
            }
            usedValues.Add(v);
            fileActions += actions[v] + "\n";
            if (changedValues[v] == 0)
            {
                totalPoints += values[v];
            } else
            {
                totalPoints += changedValues[v];
            }
        }

        if (totalPoints > -10 && totalPoints < 10 && mainObject.GetComponent<MainScript>().day >= 8)
        {
            fate = 4;
        } else if (totalPoints > 0)
        {
            fate = 1;
        } else
        {
            fate = 2;
        }

        transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = fileActions;
    }

    public void updateStamp()
    {
        if (stamp == 0)
        {
            stampSpot.GetComponent<SpriteRenderer>().sprite = stampE;
        }
        else if(stamp == 1)
        {
            stampSpot.GetComponent<SpriteRenderer>().sprite = stampG;
        }
        else if(stamp == 2)
        {
            stampSpot.GetComponent<SpriteRenderer>().sprite = stampB;
        }
        else if(stamp == 3)
        {
            stampSpot.GetComponent<SpriteRenderer>().sprite = stampR;
        } else
        {
            stampSpot.GetComponent<SpriteRenderer>().sprite = stampM;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!mainObject.GetComponent<MainScript>().frozen)
        {
            if (transform.position.x < -3)
            {
                transform.position = new Vector2(transform.position.x + 5 * Time.deltaTime, transform.position.y);
            }
        }

        if (dismissing)
        {
            GetComponent<SpriteRenderer>().sortingOrder = 0;
            transform.GetChild(0).GetComponent<Canvas>().sortingOrder = 1;
            transform.GetChild(1).GetComponent<SpriteRenderer>().sortingOrder = 1;
            if (transform.position.y < 6.5)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + 9 * Time.deltaTime);
            } else
            {
                if (cactus)
                {
                    mainObject.GetComponent<MainScript>().judgeFunction(true);
                }
                else
                {
                    mainObject.GetComponent<MainScript>().judgeFunction(stamp == fate);
                }
                Destroy(gameObject);
            }
        }
    }
}
