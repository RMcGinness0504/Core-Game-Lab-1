using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class titleControl : MonoBehaviour
{
    bool fadingOut = false;
    float alpha = 1.0f;

    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1024,768, false);
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fadingOut)
        {
            alpha += 0.5f * Time.deltaTime;
            if (alpha > 1)
            {
                SceneManager.LoadScene("Scene1",LoadSceneMode.Single);
            }
        } else
        {
            alpha -= 0.5f * Time.deltaTime;
            if (alpha < 0)
            {
                alpha = 0f;
            }
        }

        sr.color = new Color(0, 0, 0, alpha);

        if (Input.anyKeyDown && alpha <= 0)
        {
            fadingOut = true;
        }
    }
}
