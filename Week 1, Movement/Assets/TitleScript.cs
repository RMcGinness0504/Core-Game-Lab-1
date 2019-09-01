using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScript : MonoBehaviour
{
    public GameObject black;

    public Text pressSpace;

    public float alpha = 1.0f;
    public bool fadingOut = false;

    public float timeVar;

    public float textTimer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(364, 720, false);
        alpha = 1.0f;
        fadingOut = false;
    }

    // Update is called once per frame
    void Update()
    {
        timeVar = Time.deltaTime;

        textTimer = textTimer + timeVar;
        if (textTimer % 2 <= 1)
        {
            pressSpace.color = new Color(1, 1, 1, 1);
        } else
        {
            pressSpace.color = new Color(1, 1, 1, 0);
        }

        if (fadingOut == true)
        {
            if (alpha < 1f)
            {
                alpha = (float)(alpha + 0.02);
                if (alpha > 0.93f)
                {
                    alpha = 1f;
                    SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
                }
            }
        }
        else
        {
            if (alpha > 0f)
            {
                alpha = (float)(alpha - 0.02);
                if (alpha < 0.07f)
                {
                    alpha = 0;
                }
            }
        }

        black.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, alpha);

        if (Input.GetKey(KeyCode.Space) && alpha <= 0)
        {
            fadingOut = true;
        }
    }
}
