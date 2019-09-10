using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class titleControl : MonoBehaviour
{
    public bool fadingOut = false;
    public float alpha = 1.0f;
    bool goingToHelp = false;
    bool helpShown = false;

    public GameObject helpBG;
    public Text tex;
    public GameObject black;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fadingOut)
        {
            alpha = alpha + (float)(0.6 * Time.deltaTime);
            if (alpha >= 1)
            {
                alpha = 1.0f;
                fadingOut = false;
                if (helpShown)
                {
                    helpShown = false;
                    tex.color = new Color(0, 0, 0, 0);
                    helpBG.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
                }
                else if (goingToHelp)
                {
                    helpShown = true;
                    tex.color = new Color(0, 0, 0, 255);
                    helpBG.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
                }
                else
                {
                    SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
                }
            }
        } else
        {
            alpha = alpha - (float)(0.6 * Time.deltaTime);
            if (alpha <= 0)
            {
                alpha = 0.0f;
            }
        }

        black.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, alpha);

        helpBG.transform.position = new Vector2((float)((helpBG.transform.position.x + 2 * Time.deltaTime) % 0.96), (float)((helpBG.transform.position.y - 2 * Time.deltaTime) % 0.96));

        if (!fadingOut && alpha <= 0.0f)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                fadingOut = true;
                goingToHelp = false;
            } else if (Input.GetKeyDown(KeyCode.Return))
            {
                fadingOut = true;
                goingToHelp = true;
            }
        }
    }
}
