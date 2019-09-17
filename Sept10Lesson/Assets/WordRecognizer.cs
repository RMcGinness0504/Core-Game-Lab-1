using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordRecognizer : MonoBehaviour
{
	List<string> letters = new List<string>();

    public Text myText;

    public string[] myWords = { "BEANS", "GRAINS", "VEGETABLES", "CHEESE", "YOGURT", "GOGURT", "LUNCHABLES" };

    public string myWord = "BEANS";

    // Start is called before the first frame update
    void Start()
    {
        myWord = myWords[Random.Range(0, myWords.Length-1)];
        myText.text = myWord;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGUI()
	{
        if(Event.current.type == EventType.KeyDown && Event.current.keyCode != KeyCode.None)
		{
			letters.Add(Event.current.keyCode.ToString());

            for(int i = 0; i < letters.Count;i++)
            {
                if (letters[i][0] == myWord[i])
                {
                    Debug.Log("YAY");
                    myText.color = Color.green;
                    if (letters.Count == myWord.Length)
                    {
                        myText.color = Color.magenta;
                        myText.fontStyle = FontStyle.Bold;
                        letters.Clear();
                        myWord = myWords[Random.Range(0, myWords.Length - 1)];
                    }
                } else
                {
                    letters.Clear();
                    Debug.Log("wrong");
                    myText.color = Color.red;
                }
            }
		}

	}
}
