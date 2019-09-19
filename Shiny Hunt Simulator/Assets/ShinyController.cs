using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class ShinyController : MonoBehaviour
{
    public GameObject black;
    public GameObject grassL;
    public GameObject grassR;

    public GameObject upArrow;
    public GameObject downArrow;
    public GameObject enterButton;
    public GameObject aButton;
    public GameObject bButton;

    public GameObject ballTop;
	public GameObject ballBottom; //2.1 -> 0.3

    public GameObject shinySparkle;
    public GameObject caughtSparkle;

    public AudioSource musicSource;
    public AudioSource caughtSource;
    public AudioSource shinySound;

    public GameObject notAPokemonNintendoPleaseDontSue;

    public Sprite[] chars = new Sprite[24];
    public Sprite[] charsShiny = new Sprite[24];

    public Sprite upArrowU;
    public Sprite upArrowD;
    public Sprite downArrowU;
    public Sprite downArrowD;
    public Sprite enterU;
    public Sprite enterD;
    public Sprite aU;
    public Sprite aD;
    public Sprite bU;
    public Sprite bD;

    bool hasDoneFirstGrassSound = false;

    public Text huntingText;

    public static float cursorTimerMax = 0.25f;
    float cursorTimer = cursorTimerMax;

    string[] names = { "Piguin", "Wornet", "Burriel", "Ider", "Ceecle", "Mobeel", "Zigster", "Maxim", "Henrat", "Raisin", "Packer", "Stacker", "Isee", "Treble", "Killboard", "Sak", "Rokomet", "Yoofoo", "Urpin", "Goobor", "Spryte", "Spoars", "Crub", "Malarch" };

    int[] numSeen = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    int[] numShiny = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    int[] numMissed = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

    bool notPokemonShown;
	bool catching = false;

    int rand = 99999;

    bool fadingOut = false;
    float alpha = 1.0f;
    int notPokemonHunting = 1;

    private void resetNotPokemon()
    {
        if (rand == 1)
        {
            numMissed[notPokemonHunting - 1]++;
        }

        if (hasDoneFirstGrassSound)
        {
            grassL.GetComponent<AudioSource>().Play();
        }

        notPokemonShown = false;
        if (!musicSource.isPlaying)
        {
            musicSource.Play();
        }
        grassL.transform.position = new Vector2(0.45f, 0.18f);
        grassR.transform.position = new Vector2(1.829f, 0.18f);
        ballTop.transform.position = new Vector2(1.14f, 2.1f);
        ballBottom.transform.position = new Vector2(1.149f, -2f);
        notAPokemonNintendoPleaseDontSue.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0);
        notAPokemonNintendoPleaseDontSue.transform.localScale = new Vector3(6, 6, 6);
        rand = 0;
        huntingText.text = "Now hunting: " + names[notPokemonHunting - 1];

        bButton.GetComponent<SpriteRenderer>().color = new Color(0.471f, 0.471f, 0.471f);
    }

    // Start is called before the first frame update
    void Start()
    {
        numSeen = SaveAndLoad.Load().numSeen;
        numShiny = SaveAndLoad.Load().numShiny;
        numMissed = SaveAndLoad.Load().numMissed;
        resetNotPokemon();
        notAPokemonNintendoPleaseDontSue.GetComponent<SpriteRenderer>().sprite = chars[notPokemonHunting - 1];
        notAPokemonNintendoPleaseDontSue.GetComponent<SpriteRenderer>().color = new Color(0,0,0);
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
				Data dt = new Data(numSeen, numShiny, numMissed);
				SaveAndLoad.Save(dt);
                SceneManager.LoadScene("menu", LoadSceneMode.Single);
            }
        }
        else
        {
            alpha = alpha - (float)(0.6 * Time.deltaTime);
            if (alpha <= 0)
            {
                alpha = 0.0f;
                if (!hasDoneFirstGrassSound)
                {
                    grassL.GetComponent<AudioSource>().Play();
                    hasDoneFirstGrassSound = true;
                }
            }
        }

        black.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, alpha);

        //Buttons
            if (Input.GetKey(KeyCode.DownArrow))
            {
                downArrow.GetComponent<SpriteRenderer>().sprite = downArrowD;
            } else
            {
                downArrow.GetComponent<SpriteRenderer>().sprite = downArrowU;
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                upArrow.GetComponent<SpriteRenderer>().sprite = upArrowD;
            }
            else
            {
                upArrow.GetComponent<SpriteRenderer>().sprite = upArrowU;
            }

            if (Input.GetKey(KeyCode.Return))
            {
                enterButton.GetComponent<SpriteRenderer>().sprite = enterD;
            }
            else
            {
                enterButton.GetComponent<SpriteRenderer>().sprite = enterU;
            }

            if (Input.GetKey(KeyCode.A))
            {
                aButton.GetComponent<SpriteRenderer>().sprite = aD;
            }
            else
            {
                aButton.GetComponent<SpriteRenderer>().sprite = aU;
            }

            if (Input.GetKey(KeyCode.B))
            {
                bButton.GetComponent<SpriteRenderer>().sprite = bD;
            }
            else
            {
                bButton.GetComponent<SpriteRenderer>().sprite = bU;
            }
        //////

        if (catching)
		{
            if(ballTop.transform.position.y > 0.34)
			{
				ballTop.transform.position = new Vector2(ballTop.transform.position.x, ballTop.transform.position.y - Time.deltaTime);
				ballBottom.transform.position = new Vector2(ballBottom.transform.position.x, ballBottom.transform.position.y + Time.deltaTime);

                notAPokemonNintendoPleaseDontSue.transform.localScale = new Vector3((float)(ballTop.transform.position.y / 2.1*6), (float)(ballTop.transform.position.y / 2.1*6), 6);
			} else
            {
                catching = false;
                caughtSource.Play();
                for (int i = 1; i <= 5; i++)
                {
                    Instantiate(caughtSparkle, new Vector3(notAPokemonNintendoPleaseDontSue.transform.position.x, notAPokemonNintendoPleaseDontSue.transform.position.y, notAPokemonNintendoPleaseDontSue.transform.position.z), Quaternion.identity);
                }
                numShiny[notPokemonHunting - 1]++;
                rand = 9999;
            }
		}

        if (!fadingOut && alpha <= 0 && !catching && !caughtSource.isPlaying)
        {
            grassL.transform.position = new Vector2(grassL.transform.position.x - (float)(Time.deltaTime*0.85), grassL.transform.position.y);
            grassR.transform.position = new Vector2(grassR.transform.position.x + (float)(Time.deltaTime*0.85), grassR.transform.position.y);
			if (Input.GetKeyDown(KeyCode.A) && notPokemonShown)
			{
                resetNotPokemon();
            }
			else if (grassR.transform.position.x >= 3.1 && !notPokemonShown)
            {
                rand = UnityEngine.Random.Range(0, 65);
                if (rand == 1)
                {
                    notAPokemonNintendoPleaseDontSue.GetComponent<SpriteRenderer>().sprite = charsShiny[notPokemonHunting - 1];
                    shinySound.Play();
                    for(int i = 0;i < 11;i++)
                    {
                        Instantiate(shinySparkle, new Vector3(notAPokemonNintendoPleaseDontSue.transform.position.x, notAPokemonNintendoPleaseDontSue.transform.position.y, notAPokemonNintendoPleaseDontSue.transform.position.z),Quaternion.identity);
                    }
                    bButton.GetComponent<SpriteRenderer>().color = new Color(1,1,1);
                } else
                {
                    grassR.GetComponent<AudioSource>().Play();
                    notAPokemonNintendoPleaseDontSue.GetComponent<SpriteRenderer>().sprite = chars[notPokemonHunting - 1];
                    bButton.GetComponent<SpriteRenderer>().color = new Color(0.471f, 0.471f, 0.471f);
                }
                notPokemonShown = true;
                numSeen[notPokemonHunting - 1]++;
                notAPokemonNintendoPleaseDontSue.GetComponent<SpriteRenderer>().color = new Color(255,255,255);
            }  else if (Input.GetKeyDown(KeyCode.Return))
            {
                fadingOut = true;
                enterButton.GetComponent<AudioSource>().Play();
                if (rand == 1)
                {
                    numMissed[notPokemonHunting - 1]++;
                }
            } else if(Input.GetKeyDown(KeyCode.B) && rand == 1)
			{
				catching = true;
                bButton.GetComponent<SpriteRenderer>().color = new Color(0.471f,0.471f,0.471f);
                musicSource.Pause();
                ballBottom.GetComponent<AudioSource>().Play();
            } else if(Input.GetKeyDown(KeyCode.UpArrow) && notPokemonHunting > 1)
            {
                resetNotPokemon();
                notPokemonHunting--;
                upArrow.GetComponent<AudioSource>().Play();
                notAPokemonNintendoPleaseDontSue.GetComponent<SpriteRenderer>().sprite = chars[notPokemonHunting - 1];

                huntingText.text = "Now hunting: " + names[notPokemonHunting - 1];
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) && notPokemonHunting < 24)
            {
                resetNotPokemon();
                notPokemonHunting++;
                upArrow.GetComponent<AudioSource>().Play();
                notAPokemonNintendoPleaseDontSue.GetComponent<SpriteRenderer>().sprite = chars[notPokemonHunting - 1];

                huntingText.text = "Now hunting: " + names[notPokemonHunting - 1];
            }
            else if (Input.GetKey(KeyCode.R) && Input.GetKey(KeyCode.T))
            {
				Array.Clear(numSeen,0,24);
				Array.Clear(numShiny, 0, 24);
				Array.Clear(numMissed, 0, 24);
            }
        }
    }
}
