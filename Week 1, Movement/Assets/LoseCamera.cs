using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCamera : MonoBehaviour
{

    public GameObject black;
    public AudioSource loseAud;

    public float musicTimer = 17.0f;

    public float timeVar;

    public float alpha = 1.0f;
    public bool fadingOut = false;

    // Start is called before the first frame update
    void Start()
    {
        musicTimer = 17.0f;
        alpha = 1.0f;
        fadingOut = false;

        loseAud.Play();
    }

    // Update is called once per frame
    void Update()
    {
        timeVar = Time.deltaTime;

        musicTimer = musicTimer - timeVar;
        if (musicTimer <= 0)
        {
            fadingOut = true;
        }

        if (fadingOut == true)
        {
            if (alpha < 1f)
            {
                alpha = (float)(alpha + 0.02);
                if (alpha > 0.93f)
                {
                    alpha = 1f;
                    SceneManager.LoadScene("Title", LoadSceneMode.Single);
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
    }
}
