using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraControl : MonoBehaviour
{
    public GameObject playerObject;
    public GameObject bgObject;
    public GameObject doomWaterOfDoom;
    public GameObject black;

    public AudioSource audSource;

    public float introCameraTimer = 8.0f;
    public float waterSpeed = 0.15f;

    public float timeVar;

    public float alpha = 1.0f;
    public bool fadingOut = false;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, playerObject.transform.position.y + 3, -10);
    }

    // Update is called once per frame
    void Update()
    {
        timeVar = Time.deltaTime;

        if (fadingOut == true)
        {
            if (alpha < 1f)
            {
                alpha = (float)(alpha + 0.002);
                if (alpha > 0.93f)
                {
                    alpha = 1f;
                    SceneManager.LoadScene("Lose", LoadSceneMode.Single);
                }
            }
        } else
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
        black.transform.position = new Vector3(0, transform.position.y, -1);

        if (playerObject.transform.position.y <= doomWaterOfDoom.transform.position.y + 3.2)
        {
            playerObject.GetComponent<PlayerController>().playerDead = true;
            playerObject.GetComponent<PlayerController>().verticalSpeed = (float)-0.07;
            fadingOut = true;
        }
        else
        {
            waterSpeed = (float)(waterSpeed + 0.07*Time.deltaTime);
            doomWaterOfDoom.transform.position = new Vector2(0, (float)(doomWaterOfDoom.transform.position.y + (timeVar * waterSpeed)));
        }

        if (introCameraTimer <= 0 && playerObject.GetComponent<PlayerController>().playerDead == false) 
        {
            transform.position = new Vector3(0, playerObject.transform.position.y + 3, -10);

            bgObject.transform.position = new Vector2(0, (float)(transform.position.y - (transform.position.y % 1)));
        } else {
            introCameraTimer = introCameraTimer - timeVar;
        }

        if (introCameraTimer >= 5)
        {
            transform.position = new Vector3(0, (float)(transform.position.y - 0.003),-10);
        }
        else if (introCameraTimer >= 3)
        {

        }
        else if (introCameraTimer > 0)
        {
            transform.position = new Vector3(0, (float)(transform.position.y + 0.003),-10);
            if (transform.position.y > playerObject.transform.position.y + 3)
            {
                introCameraTimer = 0;
            }
        }
    }
}
