using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour
{
    public GameObject fade;

    public bool fadingToBlack = false;

    public float alpha = 1.0f;

    // Start is called before the first frame update
    void Start()
	{
		Screen.SetResolution(1440,960, false);
		Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (fadingToBlack)
        {
            alpha = (float)(alpha + Time.deltaTime * 0.3);
            if (alpha >= 1.0f)
            {
                alpha = 1.0f;
                fadingToBlack = false;
                SceneManager.LoadScene("game", LoadSceneMode.Single);
            }
        } else
        {
            alpha = (float)(alpha - Time.deltaTime * 0.3);
            if (alpha <= 0.0f)
            {
                alpha = 0.0f;
            }
        }

        fade.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, alpha);

        if (Input.GetMouseButtonDown(0) && alpha <= 0.0f)
        {
            fadingToBlack = true;
            //sound play
        }
    }
}
