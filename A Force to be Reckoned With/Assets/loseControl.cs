using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loseControl : MonoBehaviour
{
    public GameObject[] people = new GameObject[3];

    public bool fadingOut = false;
    public float alpha = 1.0f;
    float angle = 0.0f;

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
                SceneManager.LoadScene("title", LoadSceneMode.Single);
            }
        }
        else
        {
            alpha = alpha - (float)(0.6 * Time.deltaTime);
            if (alpha <= 0)
            {
                alpha = 0.0f;
            }
        }

        black.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, alpha);

        if (!fadingOut && alpha <= 0.0f)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
            {
                fadingOut = true;
            }
        }

        for (int i = 0;i < 3;i++)
        {
            people[i].transform.position = new Vector2(people[i].transform.position.x, people[i].transform.position.y + (3 * Time.deltaTime));
            angle = angle + 60*Time.deltaTime;
            people[i].transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            if (people[i].transform.position.y > 6)
            {
                people[i].transform.position = new Vector2(people[i].transform.position.x, people[i].transform.position.y * -1);
            }
        }
    }
}
