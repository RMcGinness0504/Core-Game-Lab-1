using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuControl : MonoBehaviour
{
    public GameObject black;
    public GameObject backSpace;
    public GameObject spaceBar;
    public GameObject upArrow;
    public GameObject downArrow;
    public GameObject cursorObject;

    public GameObject shinySparkle;

    public Sprite backDown;
    public Sprite backUp;
    public Sprite spaceDown;
    public Sprite spaceUp;

    public Sprite mystery;
    public AudioSource shinySound;

    public AudioSource cursorSound;

    public GameObject[] boxes = new GameObject[4];
    public GameObject[] stars = new GameObject[4];

    public Sprite[] chars = new Sprite[24];
    public Sprite[] charsShiny = new Sprite[24];

    public static float cursorTimerMax = 0.25f;
    float cursorTimer = cursorTimerMax;

    string[] names = {"Piguin", "Wornet", "Burriel","Ider","Ceecle","Mobeel","Zigster","Maxim","Henrat","Raisin","Packer","Stacker","Isee","Treble","Killboard","Sak","Rokomet","Yoofoo","Urpin","Goobor","Spryte","Spoars","Crub","Malarch"};
    string[] descriptions = {"Found exclusively the New England states, this brazen bird wanders around with a cyan letter on its stomach.", "The sting of a Wornet is known far and wide to be extremely painful, and occasionally fatal.", "When large deposits of acorns are found buried in a yard, it's almost certainly a sign of Burriel.", "Despite the incisors, Ider are generally friendly, and seek companionship from the humans whose house it occupies.", "It's advised not to bother Ceecles, as they can follow their enemies without tiring or slowing.", "In the suburbs, motorists have been known to brake for these machinations, mistaking them for real cars.", "This high-strung, rat-like creature snacks on all sorts of garbage, plants, and bugs.", "Due to its dog-like appearance, this wild creature has been mistakenly brought to kennels and adoption centers.", "In the plains of the midwest, a curious creature can be found. One that's part deer, dog, and horse.", "A creature similar to a cat, but with a grape-like skin, and the ability to gain energy in sunlight.", "After being filled with junk and moved across the country, this box has had enough.", "A whole stack of Packers, all working together for a common goal- becoming a boxing champ.", "Isee tend to travel in packs, rebuilding any friends who lose an arm, hat, or button.", "A troubling music note with a large mouth. By making a high-pitched noise, it can float upwards.", "Thousands of innocent people have been terrified by this thing, which lies dormant until its pray approaches.", "Greedy people who mistake Sak for a money bag are met with an unforgiving barrage of teeth.", "Swarms of this living comet return to the earth every seventy years, where lucky trainers attempt to catch some.", "Bright lights referenced in ancient literature are often speculated to be the anomalous machines.", "A mysterious urchin-like creature from outer space. It's barbs are sharp enough to pierce steel.", "A strange peanut with a goofy grin. Found in the outer reaches of space, no one's sure where it came from.", "An incredibly bright fairy, native to the town of Groveland but found in the surrounding mountains, as well.", "A group of poisonous molecules. It's hypothesized that large numbers of them could cause a mass extinction.", "A fun-loving crab, with an impressive jumping ability. Commonly found in sewers around the world.", "A regal-looking cat with an expensive robe. Although militaristic, it can be tamed easily with treats."};
    int[] numSeen;
    int[] numShiny;
    int[] numMissed;
    int topChar = 1;
    int charSelected = 1;
    bool shinyShown = false;

    public Text nameAndDescription;
    public Text numbers;
    public Text globalNumbers;

    bool fadingOut = false;
    float alpha = 1.0f;

    private void updateChar(int n)
    {
        if (numSeen[n - 1] > 0)
        {
            nameAndDescription.text = "Name: " + names[n-1] + "\n" + descriptions[n-1];
        }
        else
        {
            nameAndDescription.text = "Name: ??????";
        }

        if (numShiny[n - 1] <= 0)
        {
            spaceBar.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
        } else
        {
            spaceBar.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
        }

        numbers.text = "Seen: " + numSeen[n-1] + "\nShinies Caught: " + numShiny[n-1] + "\nShinies Missed: " + numMissed[n-1];

        upArrow.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        downArrow.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);

        shinyShown = false;

        if (topChar == 1)
        {
            upArrow.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        }

        if (topChar == 21)
        {
            downArrow.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        }

        for (int i = 0; i <= 3; i++)
        {
            if (numSeen[topChar + i - 1] > 0)
            {
                boxes[i].GetComponent<SpriteRenderer>().sprite = chars[topChar + i - 1];
            }
            else
            {
                boxes[i].GetComponent<SpriteRenderer>().sprite = mystery;
            }

            if (numShiny[topChar + i - 1] > 0)
            {
                stars[i].GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
            } else
            {
                stars[i].GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        numSeen = SaveAndLoad.Load().numSeen;
        numShiny = SaveAndLoad.Load().numShiny;
        numMissed = SaveAndLoad.Load().numMissed;
        updateChar(topChar + charSelected - 1);
        cursorSound = upArrow.GetComponent<AudioSource>();

        int seenTotal = 0;
        int shinyTotal = 0;
        int missedTotal = 0;

        for(int i = 0;i < numSeen.Length;i++)
        {
            seenTotal += numSeen[i];
            shinyTotal += numShiny[i];
            missedTotal += numMissed[i];
        }
        globalNumbers.text = "Seen: " + seenTotal + ", Shinies Caught: " + shinyTotal + ", Shinies Missed: " + missedTotal;
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
                SceneManager.LoadScene("game", LoadSceneMode.Single);
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

        if (Input.GetKey(KeyCode.Backspace))
        {
            if (!fadingOut)
            {
                backSpace.GetComponent<AudioSource>().Play();
            }

            backSpace.GetComponent<SpriteRenderer>().sprite = backDown;
            fadingOut = true;
        } else
        {
            backSpace.GetComponent<SpriteRenderer>().sprite = backUp;
        }

        cursorTimer = cursorTimer - Time.deltaTime;

        if (Input.GetKey(KeyCode.Space))
        {
            spaceBar.GetComponent<SpriteRenderer>().sprite = spaceDown;
        } else
        {
            spaceBar.GetComponent<SpriteRenderer>().sprite = spaceUp;
        }

        if (!fadingOut && cursorTimer <= 0)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (charSelected == 2 || charSelected == 4)
                {
                    cursorObject.transform.position = new Vector2((float)(cursorObject.transform.position.x - 3.5), cursorObject.transform.position.y);
                    charSelected--;
                    updateChar(charSelected + topChar - 1);
                    cursorSound.Play();
                    cursorTimer = cursorTimerMax;
                }
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                if (charSelected == 1 || charSelected == 3)
                {
                    cursorObject.transform.position = new Vector2((float)(cursorObject.transform.position.x + 3.5), cursorObject.transform.position.y);
                    charSelected++;
                    updateChar(charSelected + topChar - 1);
                    cursorSound.Play();
                    cursorTimer = cursorTimerMax;
                }
            }
            else if (Input.GetKey(KeyCode.UpArrow) && (charSelected + topChar - 1) > 2)
            {
                cursorTimer = cursorTimerMax;
                if (charSelected == 3 || charSelected == 4)
                {
                    cursorObject.transform.position = new Vector2(cursorObject.transform.position.x, (float)(cursorObject.transform.position.y + 3.5));
                    charSelected-=2;
                } else
                {
                    topChar-=2;
                }
                updateChar(charSelected + topChar - 1);
                cursorSound.Play();
            }
            else if (Input.GetKey(KeyCode.DownArrow) && (charSelected + topChar - 1) < 23)
            {
                cursorTimer = cursorTimerMax;
                if (charSelected == 1 || charSelected == 2)
                {
                    cursorObject.transform.position = new Vector2(cursorObject.transform.position.x, (float)(cursorObject.transform.position.y - 3.5));
                    charSelected += 2;
                }
                else
                {
                    topChar += 2;
                }
                updateChar(charSelected + topChar - 1);
                cursorSound.Play();
            } else if(Input.GetKey(KeyCode.Space) && numShiny[charSelected + topChar - 2] >= 1)
            {
                cursorTimer = cursorTimerMax;
                if (shinyShown)
                {
                    boxes[charSelected - 1].GetComponent<SpriteRenderer>().sprite = chars[charSelected + topChar - 2];
                    shinyShown = false;
                    backSpace.GetComponent<AudioSource>().Play();
                } else { 
                    shinySound.Play();
                    boxes[charSelected - 1].GetComponent<SpriteRenderer>().sprite = charsShiny[charSelected + topChar - 2];
                    shinyShown = true;
                    for (int i = 0; i < 11; i++)
                    {
                        Instantiate(shinySparkle, new Vector3(boxes[charSelected -1].transform.position.x, boxes[charSelected - 1].transform.position.y, boxes[charSelected - 1].transform.position.z), Quaternion.identity);
                    }
                }
            }
        }
    }
}
