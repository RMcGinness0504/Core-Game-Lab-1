using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainScript : MonoBehaviour
{
    public int day = 0;
    int filesLeft = 5;
    int strikes = 5;

    public Text pointTextL;
    public Text pointTextR;
    public Text pointNumbersL;
    public Text pointNumbersR;
    public Text rulesTextL;
    public Text rulesTextR;
    public Text messageText;
    public Text changeText;

    public GameObject filePrefab;
    public GameObject watchObj;
    public GameObject deskObj;

    float timer = 0;
    float timerMax = 200f;

    public bool frozen = true;

    string[] rulesL = {"\t\tAny human with points less than or equal to zero is sent to The Bad Place, otherwise, they are sent to The Good Place.","\t\tIf you get more than five strikes on your record, you will be marbelized.","\t\tYou must judge five humans within 180 seconds.","\t\tLook at the Changes sheet for any changes to point values.","\t\tThe time constraints have changed to 150 seconds."};
    string[] rulesR = {"","","","","","\t\tIf any profile has three or more typos on it, it must be sent back to Afterlife Management.","\t\tAny counterfeit seals must also be rejected, which you can compare with the seal on this Rule Book.","\t\tAny humans between -10 and 10 points are to be sent to The Medium Place.","\t\tYou must now judge seven humans within the time limit."};

    string[] dailyMessages = { "Hello new hire,\n\t\tWelcome to your first day working for Accounting. Today, your only task is to review the files of five humans, and determine if they go to The Good Place or The Bad Place, by stamping and submitting their papers. End of statement.\n\nManagement" ,"Hello new hire,\n\t\tThank you for completing your first assignment, day two will now commence. Due to regulations from the governing body, \"We can't have you dinguses messing up the files anymore.\" In the future, any incorrect submissions will result in a strike. After five strikes, you will be marbelized. End of statement.\n\nManagement","Hello new hire,\n\t\tWelcome to your third day of working in accounting. Due to efficiency complaints, we will be limiting the amount of time you have to review files. After 180 seconds, you will be penalized for any un-checked files. End of statement.\n\nManagment"};

    string[] actions = { "Called a woman \"Toots.\"","Read a book to a child.","Worked at a school.","Worked at a college.","Enjoyed deep-dish pizza.","Owned a pet daschund.","Worked at a DMV.","Was a tour guide.","Enjoyed thin crust pizza.","Unironically listened to dubstep.","Read \"How the Grinch Stole Christmas.\"","Rode a bicycle in New York City.","Backed a project on Kickstarter.","Worked retail.","Adopted a hairless cat.","Replied, \"It's going,\" after being asked \"How's it going?\""};
    int[] values = { -10, 5, 24, 19, -4, -7, -25, -17, 6, -7, 34, -8, 5, 28, 21, -3 };
    int[] changedValues = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    int[] changeValues = { -14, 7, 28, 18, 5, -8, -16, -19, 9, -4, 35, -12, 1, 31, 20, -5 };
    public List<int> usedNums;
    public List<bool> updatedNums;
    int valuesChangedInt;

    public GameObject[] strikeObjects = new GameObject[5];

    public List<string> bookActions;
    public List<int> bookPoint;

    public void createFile()
    {
        if (filesLeft > 0)
        {
            filesLeft--;
            GameObject f = Instantiate(filePrefab, new Vector2(-7, 1), Quaternion.identity);
            f.GetComponent<FileScript>().actions = bookActions;
            f.GetComponent<FileScript>().values = bookPoint;
            f.GetComponent<FileScript>().changedValues = changedValues;
        }
        else
        {
            startDay();
        }
    }

    public void updateValues()
    {
        int r = Random.Range(0, 2);
        int v = Random.Range(0, actions.Length);
        for (int i = 1; i <= r; i++)
        {
            if (valuesChangedInt > 7)
            {
                break;
            }

            int z = 0;

            while (changedValues[v] != 0)
            {
                z++;
                if (z > 20)
                {
                    break;
                }
                v = Random.Range(0, actions.Length);
            }
            changedValues[v] = changeValues[v];
            valuesChangedInt++;
        }

        string t = "";
        for(int i = 0;i < changedValues.Length;i++)
        {
            if (changedValues[i] != 0)
            {
                t += actions[i] + ", " + changedValues[i] + "\n";
            }
        }
        changeText.GetComponent<Text>().text = t;
    }

    public bool tableContains(List<int> t, int c)
    {
        for (int i = 0;i < t.Count;i++)
        {
            if (t[i] == c)
            {
                return true;
            }
        }
        return false;
    }

    public void startDay()
    {
        frozen = true;
        filesLeft = 5;
        day++;
        if (day >= 3)
        {
            timer = timerMax;
        }

        if (day >= 9)
        {
            filesLeft = 7;
        }

        if (day >= 4)
        {
            updateValues();
        }

        addActions();
        updateBooks();
    }

    public void addActions()
    {
        int actionsToAdd = 3;
        if (day == 1)
        {
            actionsToAdd = 12;
        }

        for (int i = bookActions.Count; i < actionsToAdd + bookActions.Count;i++)
        {
            if (i < actions.Length)
            {
                bookActions.Add(actions[i]);
                bookPoint.Add(values[i]);
                actionsToAdd--;
            }
        }
    }

    public void updateBooks()
    {
        pointTextL.text = "";
        pointTextR.text = "";
        pointNumbersL.text = "";
        pointNumbersR.text = "";

        for (int i = 0;i < bookActions.Count;i++)
        {
            if (i < 26)
            {
                pointTextL.text += bookActions[i] + "\n";
                pointNumbersL.text += bookPoint[i] + "\n";
            } else
            {
                pointTextR.text += bookActions[i] + "\n";
                pointNumbersR.text += bookPoint[i] + "\n";
            }
        }
        
        rulesTextL.text += rulesL[day - 1];
        rulesTextR.text += rulesR[day - 1];

        messageText.text = dailyMessages[day - 1];
    }

    // Start is called before the first frame update
    void Start()
    {
        startDay();

        Screen.SetResolution(1024,768, false);
    }

    // Update is called once per frame
    void Update()
    {
        if (day >= 3 && timer > 0 && !frozen)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                while (filesLeft > 0)
                {
                    strikes--;
                    filesLeft--;
                    Destroy(strikeObjects[strikes]);
                    if (strikes <= 0)
                    {
                        deskObj.GetComponent<AudioSource>().Stop();
                        SceneManager.LoadScene("lose", LoadSceneMode.Single);
                    }
                }
            }
            watchObj.transform.eulerAngles = new Vector3(0,0,timer/timerMax * 360);
        }
    }

    public void judgeFunction(bool x)
    {
        if (x)
        {
            GetComponents<AudioSource>()[0].Play();
        } else
        {
            if (day > 1 && !frozen || day > 2)
            {
                strikes--;
                Destroy(strikeObjects[strikes]);
                if (strikes <= 0)
                {
                    deskObj.GetComponent<AudioSource>().Stop();
                    SceneManager.LoadScene("lose", LoadSceneMode.Single);
                }
            }
            GetComponents<AudioSource>()[1].Play();
        }
    }

    private void OnMouseDown()
    {
        if (!frozen)
        {
            if (GameObject.FindGameObjectWithTag("file").gameObject.transform.position.x >= -3 && !GameObject.FindGameObjectWithTag("file").gameObject.GetComponent<FileScript>().dismissing)
            {
                GameObject.FindGameObjectWithTag("file").gameObject.GetComponent<FileScript>().dismissing = true;
                createFile();
            }
        }
    }
}
