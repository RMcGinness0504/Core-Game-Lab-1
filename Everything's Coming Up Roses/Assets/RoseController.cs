using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoseController : MonoBehaviour
{
    public GameObject fade;
    public GameObject seed;
    public GameObject piece;
    public GameObject bugObject;

    public Text scoreText;

    public int combo = 0;
    public int score = 0;

    float bugTimer = 0f;
    public float bugTimerMax = 4.0f;

    public bool fadingToBlack = false;

    public int roseHealth = 5;
    public static float roseInvincibilityTimer = 2.0f;
    float invincible = 0.0f;

    public float alpha = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "SCORE " + score.ToString("D6");

        if (fadingToBlack)
        {
            alpha = (float)(alpha + Time.deltaTime * 0.3);
            if (alpha >= 1.0f)
            {
                alpha = 1.0f;
                fadingToBlack = false;

                SceneManager.LoadScene("title", LoadSceneMode.Single);
            }
        }
        else
        {
            alpha = (float)(alpha - Time.deltaTime * 0.3);
            if (alpha <= 0.0f)
            {
                alpha = 0.0f;
            }
        }

        fade.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, alpha);

        if (alpha <= 0.0f)
        {
            bugTimer = bugTimer - Time.deltaTime;
            invincible = invincible - Time.deltaTime;

            if (Input.GetMouseButtonDown(0) && roseHealth > 0)
            {
                GameObject s = Instantiate(seed, new Vector3(0, 0, 0), Quaternion.identity);
                Vector3 mousePos = Input.mousePosition;
                mousePos.z = 0f;

                Vector3 objectPos = Camera.main.WorldToScreenPoint(new Vector3(0, 0, 0));
                mousePos.x = mousePos.x - objectPos.x;
                mousePos.y = mousePos.y - objectPos.y;

                float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg - 90;
                s.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            }

            if (bugTimer <= 0)
            {
                bugTimer = bugTimerMax;
                bugTimerMax = bugTimerMax * 0.9875f;
                if (Random.value > 0.5)
                {
                    Instantiate(bugObject, new Vector2(Random.Range(-8.0f, -11.0f), Random.Range(0.0f,5.0f)), Quaternion.identity);
                } else
                {
                    Instantiate(bugObject, new Vector2(Random.Range(8.0f, 11.0f), Random.Range(0.0f, 5.0f)), Quaternion.identity);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bug" && invincible <= 0)
        {
            invincible = roseInvincibilityTimer;
            roseHealth--;
            GetComponent<Animator>().SetInteger("health", roseHealth);

            for(int i = 1;i <= 4;i++)
            {
                Instantiate(piece, new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)), Quaternion.identity);
            }
        }
    }
}
