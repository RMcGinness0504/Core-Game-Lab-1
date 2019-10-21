using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour
{
    GameObject fade;
    float alpha = 1.0f;
    bool fadingOut = false;

    SpriteRenderer sr;

    int scene = 1;

    public int birdsKilled = 0;
    int birdLives = 5;
    public int savedBirds = 0;
    public int birdsMade = 0;
    int birdsMax = 10;
    float birdTimerMax = 7f;
    float birdTimer = 0f;

    public GameObject natuPrefab;

    public static GameControllerScript reference;

    private void Awake()
    {
        if (reference == null)
        {
            reference = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void updateUI()
    {
        GameObject textObject = GameObject.Find("numberSaved");
        textObject.GetComponent<Text>().text = "" + savedBirds + " / " + birdsMax;
        for (int i = 0;i < birdsKilled && i < 5;i++)
        {
            GameObject lifeObject = GameObject.Find("lives" + i);
            lifeObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        fade = GameObject.Find("fade");
        sr = fade.GetComponent<SpriteRenderer>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (fadingOut)
        {
            alpha += 0.5f * Time.deltaTime;
            if (alpha >= 1)
            {
                alpha = 1;
                scene++;
                if (scene >= 4 || birdsKilled >= birdLives)
                {
                    SceneManager.LoadScene("title", LoadSceneMode.Single);
                    Destroy(gameObject);
                } else
                {
                    birdsMax += 5;
                    birdTimerMax -= 1.2f;
                    fadingOut = false;
                    savedBirds = 0;
                    SceneManager.LoadScene("Scene" + scene, LoadSceneMode.Single);
                }
            }
        } else
        {
            alpha -= 0.5f * Time.deltaTime;
            if (alpha <= 0)
            {
                alpha = 0;
            }
        }

        if (sr != null)
        {
            sr.color = new Color(0, 0, 0, alpha);
        }

        if (alpha <= 0)
        {
            birdTimer -= Time.deltaTime;
            if (birdTimer <= 0 && birdsMade < birdsMax)
            {
                birdTimer += birdTimerMax;
                birdsMade++;
                Instantiate(natuPrefab, new Vector3(Random.Range(-1f, 1f), 3.75f, 0), Quaternion.identity);
            }

            if (birdsMade >= birdsMax && GameObject.FindGameObjectsWithTag("bird").Length == 0 || birdsKilled >= birdLives)
            {
                fadingOut = true;
            }
        }
    }

    private void OnLevelWasLoaded(int level)
    {
        birdsMade = 0;
        updateUI();
        fade = GameObject.Find("fade");
        sr = fade.GetComponent<SpriteRenderer>();
    }
}
