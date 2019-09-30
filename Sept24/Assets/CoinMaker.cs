using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinMaker : MonoBehaviour
{
    public GameObject coinPrefab;
    public GameObject sliderObject;
    public int coinCount;
    public GameObject textObject;
    int coinMax = 50;
    bool didBonus = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void makeCoin()
    {
        Instantiate(coinPrefab, new Vector2(Random.Range(-7f, 7f), 8), Quaternion.identity);
        coinCount++;
        if (coinCount > coinMax)
        {
            removeCoin(); 
        }
        sliderObject.GetComponent<Slider>().value = coinCount;
    }

    public void removeCoin()
    {
        if (coinCount > 0)
        {
            coinCount--;
            GameObject[] coins;
            coins = GameObject.FindGameObjectsWithTag("coin");
            Destroy(coins[Random.Range(0, coins.Length - 1)]);
        }
        sliderObject.GetComponent<Slider>().value = coinCount;
    }

    public void coinBonus()
    {
        string specialText = textObject.GetComponent<InputField>().text;
        if (specialText == "bonus" && !didBonus)
        {
            textObject.GetComponent<InputField>().text = "";
            didBonus = true;
            coinMax = 75;
            sliderObject.GetComponent<Slider>().maxValue = coinMax;
            int numOfCoinsToMake = coinMax - coinCount;
            for (int i = 1; i <= numOfCoinsToMake; i++)
            {
                makeCoin();
            }
        } else if(specialText == "blue")
        {
            textObject.GetComponent<InputField>().text = "";
            coinPrefab.GetComponent<SpriteRenderer>().color = new Color(0, 0, 1);
        } else if (specialText == "rainbow!")
        {
            textObject.GetComponent<InputField>().text = "";
            GameObject[] coins;
            coins = GameObject.FindGameObjectsWithTag("coin");
            for (int i = 0; i < coins.Length; i++)
            {
                coins[i].GetComponent<SpriteRenderer>().color = Random.ColorHSV(0,1,1,1,0.5f,1);
            }
        }
    }

    public void sliderUpdate()
	{
		int v = (int)(sliderObject.GetComponent<Slider>().value);
        if (v > coinCount)
		{
            while (v > coinCount)
			{
				makeCoin();
			}
		} else if (v < coinCount)
		{
            while(v < coinCount)
			{
				removeCoin();
			}
		}
	}
}
