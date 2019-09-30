using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainController : MonoBehaviour
{
    public List<int> usedNumbers = new List<int>(0);

    string[] names = {"Robert","Creepy Robert","Trebor","Crying Robert","Dead Robert","Super Robert","The Picture of Robert","Pointy Robert","Demon Robert","Clock Tower Robert","Phillips-CDI Robert","Beach Robert","Orange Robert","Comet Robert","Towel Robert","Edgy Robert","Blobert","Purple Robert","Curly Robert","Monster Arm Robert","Noodles & Company Robert","Lemon Robert","1920s Gangster Robert","Knight Robert","Key Lime Robert"};
	string[] locations = {"Westchester, NY", "Right behind you.", "Eastchester, NY","Missouri","Heaven","The Mushroom Kingdom","England","Lauderdale-by-the-Sea, FL","The Gates of Hell","Norway","Gamelon","Catchin' waves at the beach, brah.","Under some blankets.","Space","The bathtub.","Nowhere..........","Waffle House","Lavendar Town","Cape Cod","Silent Hill","Noodles & Company","Shelbyville","NYC","Camelot","Florida Keys"};
    string[] bios = {"Hey, the name’s Robert. I’m a game design student studying in NYC, hope we can get to know each other better!", "Ỳ̸̘̰͖̬͋͗͒̎́̃̑̀͊͢o̷̢̗̭̪̰̞̜͎͌̍́̈͌͗͞ͅú̗̲̫̭̱͍͒̃͌̎́̎͟ s̸͇͈͚͖͈̮̠͚̱̐͂͗͋̽̚͘̕͟h̷͈͔̭̝̤̭̼̜͐̿̈́́͑̏͂̆͐̍ơ̷̡͓̭͍͐̓̌͂̅̃̈́͢͟u̡̙̖̹̣̓͐̌̕̕͠ļ̶̢̡̥̗̜͇̘̳̰̂̀́̏͊̏̂͒̇͠d͎̯̲̥̫̯̈́̑̑̉̅̒̓̐ m̡̖͖̤̣̪̘͙̙̆̈́̾̑̽̍́͊͗͢e̸͈͕̟̜̥̭͔͙̤̲͒̿̐̍̈͗́͘s̸̡̛̬͎͉͙͍̲͋̿̒̍̄̾́́͟͜͝s̵̡͚̫̫̻͓͇̝̾͂̎̄̀͢͢à̵̠͎̱̣̣̣̘̏͐͛͂͐̂͒͘͢͞ͅǧ͔̭̥͉̻͇͚̜̯̆̆͛͛͗̀͜e̛̛͓̥̰̦͕͔̿͊̑̽̿̇̚ m̩̤͕̪͙̮̘͕̩̞͛͛̎͛̚͘ȩ̶̤̖͍̥̺͋̂͗̊̾͑ i̷̲̭̘͍̝̳̥̒͛͌͆̿̎̓͐̓͠f̣̻̱͕̹̤̜̂̃̀̈̓̽͘ y̦̻̬̻̯̩̅̽̇̿̀̆͐̚͜o̷̖͔͎̺̮̊͛̾̅̇͆͂͡ṷ̢̡̩̬͗̿̓͌̉̂̒͟͢͞'̛̯̪̜̯̤̯̒́̾̽̀͌́͟ṙ̴͎̤̜͍̦̬̿̍̿̌̌͛͝͠ḛ̴͔̗̫̍̒̏͊͋̒ͅ l̴̻͉̥̦͖͌͗̈͒̒͝o̢̰̭͓̤̙̤̟̽̍͗́̔̕͡͝͡ơ̝͙̳̱͚̩̗̰̹̽̔̈́͠k̶͍̩͔͍̠͕̈́̈̆͆̓̉́̕͝ȋ̠̱̫̗̜̙̟̲̥̪͐̆͆̆̑ñ̵̨̹̫͇̯̤̆̏͋́̓͋͠ͅg̛̘͙̹̲̗̫͎̜͚̑̅̍̆̄͟ f̦͓̝̪̤͓͍̘͕̜͌́̿̏̓̀̒o̡̧͙͓̩̫̟̓̒͌̾͞ͅr̴̭͍̦̘̮̮̀̉̅͗͐̈͛͞͞͞ ȃ͖̲̳̹̦͊̿͂̐̿̈̾ t̷̡̜̬͚̼͉͉̗̟͛̓̿̀̅́̾̌͡e̵̛̛̼͎̞͔̖͇̲͆̊̅͋̔̕r̶̰̘̩̤͖͐͌̋̉́r̢͉͓̭̄͐̽̌͐̐̓̔͜͠͝î͚͔̳̝̘̟̤̩̅́͊̾̓̏̑͜ͅḟ̵̨̛͔͕͍̯̇̏̐͘̕͜͡͠y̱̗͈͎͉̤͕̣͛͐̒͋̆̽͂͡i̜͈͖̭̙̼̤̖͐̀̍̿̒n̶͓̬͚̰͕̻̯̞̍́́́̓͊͌̽̑͘͟g̨̺̮͎͇̈̏̿̈́̆ t̵̬̘͔̱̼̻͗͒͑̅̕͝i̸̧̛͎͍͇̮̺̩͓̯͇̿̑͑̔́͡m̲͎͉̗͎͔͆̀̉̄̉̏͢͝ḛ̸̢̣̪̯̰͈͍̔̎̓̎̽̍̎̈,̧̝̬̼̟̇͊̉̓͊͡ b̡̨͚̺͖͈̒̀̇̒̃̒͜ͅą̵͔͓̞̺̝̯͚̄̀̆͆́͋̉͊͜b̵̨̧̛̛̝̩͎̺̈́̊̆̇͊̉͜͜͠͡ë̡̡̨̡̘͇͇̯̝̃̈̇͌̎̾e̸̢̖͙̟͓̬̠̻̗͛̉̆̃̐͒͒̍͞ḛ̹͈̯̭̤̼͂̀̎̃̆̒̔͜͢͡e̴̛̝̭͚͚͚̿̉̊̀̒͢e͚͚͔͍̻͛̃͐̀̿̂̂̿̕͟͟͜e̵͍̹̤͔̪͈̬̖̞͕̅́̋́̊̊̉̕͝.̷̨̮͉̒͌́̑̔̅̔̌͒͜͢͞ͅ", "!retteb rehto hcae wonk ot teg nac ew epoh ,CYN ni gniyduts tneduts ngised emag a m’I .treboR s’eman eht ,yeH","Yeah I'm listening to \"Before I Gaze At You Again\" from Camelot. How could you tell?","Sorry, I'm dead.","Heyyyy let’s go goomba hunting together. Sorry for the low-res pic, it’s not to hide all my blemishes and pimples, I swear.", "Lol I think something’s wrong with this portrait. Every time I eat an entire medium pizza from Domino’s in one sitting, it gets a little dirtier XD" , "If one more person tells me I look like Sonic the Hedgehog, I’m deleting my account." ,"Yo, I work at Hell, ushering all the people who like deep-dish pizza into their eternal torment. Lookin for a relationship with someone who isn't a fan of deep-dish.", "Ahoy! I’ve turned myself into a Clock Tower character and will soon be pursued by a man with a giant pair of scissors." , "Welcome to my shop! What can I interest you in? Lamp oil? Rope? Bombs? You want it, it’s yours my friend, as long as you have enough rupees…", "Only in a relationship with the sea. I’d like another partner in crime tho, maybe chill on the sand, brah?","Please help, I've been trapped under here for so long that my skin's turned orange. There's a moth in my room.","My disembodied head has become a comet, the vacumn of space is not doing well with my pores. It's so lonely up here.", "Ah~ You caught me when I was getting out of the shower. Hnnghhh so embarrassing. *bends over seductively to pick up a penny from the sidewalk*","Don't bother messaging me................. *sigh* No one understands me........","They kicked me out of the all you can eat buffet at Chucky Cheesis..... Touched the mouce...", "Hey babyyyyyyy do you want the lavender glow of love??? Also I would like some clothes shopping lessons.","What do you mean, \"interesting hair isn't a substitute for a personality?\"", "Awwww silly me. I accidentally spilled a bunch of tomato sauce on my spikey arm. Don’t worry, it’s just tomato sauce… I swear…", "Yo let me take u on a date to Noodles & Company, I get a 5% discount on orders over 40 bucks.", "I just ate a huge lemon slice because I thought it was a piece of squash. Help.","I came here to shoot crap and make craps... And I'm all out of dice.", "As a knight, I seek to defend the weak, and provide chivalry to all the gentle lords and ladies of the court. Let’s slayeth a dragon together.", "Yeah my hair is greeeeeen. Catch me working at my local farmers’ market where I sell pies: strawberry rhubarb, apple, and yes, key lime." };
    public Sprite[] pictures = new Sprite[3];

    bool beginning = false;
    public bool noDismissing = true;

    public GameObject matchPictureObject;
    public GameObject matchScreen;

    public GameObject profilePrefab;

    public void generateProfile()
    {
        if (noDismissing && transform.position.y >= 15 || !beginning)
        {
            noDismissing = false;
            if (beginning)
            {
                GameObject g = GameObject.FindGameObjectWithTag("profileM");
                if (g.GetComponent<SpriteRenderer>().sortingOrder < 3)
                {
                    g.GetComponent<SpriteRenderer>().sortingOrder = 3;
                    g.GetComponent<ProfileScript>().dismissing = true;
                    g.GetComponent<ProfileScript>().canvasObject.GetComponent<Canvas>().sortingOrder = 5;
                }
            }
            else
            {
                noDismissing = true;
            }

            if (usedNumbers.Count == names.Length)
            {
                int z = usedNumbers[usedNumbers.Count - 1];
                usedNumbers = new List<int>(0);
                usedNumbers.Add(z);
            }

            int randomInt = Random.Range(0, names.Length);
            while (tableContains(usedNumbers, randomInt))
            {
                randomInt = Random.Range(0, names.Length);
            }

            usedNumbers.Add(randomInt);

            GameObject p = Instantiate(profilePrefab, new Vector3(0, 0, 0), Quaternion.identity);
            GameObject c = transform.FindChild("Canvas").gameObject;
            p.GetComponent<ProfileScript>().name = names[randomInt];
            p.GetComponent<ProfileScript>().location = locations[randomInt];
            p.GetComponent<ProfileScript>().bio = bios[randomInt];
            p.GetComponent<ProfileScript>().pic = pictures[randomInt];
        }
    }

    public void matchProfile()
    {
        if (noDismissing && transform.position.y >= 15 || !beginning)
        {
            noDismissing = false;
            GameObject g = GameObject.FindGameObjectWithTag("profileM");
            if (g.GetComponent<SpriteRenderer>().sortingOrder < 3)
            {
                g.GetComponent<SpriteRenderer>().sortingOrder = 3;
                g.GetComponent<ProfileScript>().goodDismissing = true;
                g.GetComponent<ProfileScript>().canvasObject.GetComponent<Canvas>().sortingOrder = 5;
                matchPictureObject.GetComponent<SpriteRenderer>().sprite = g.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite;
                GetComponent<AudioSource>().Stop();
                matchScreen.GetComponent<AudioSource>().Play();
            }
            else
            {
                noDismissing = true;
            }

            
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(750,1334, false);
        Debug.Log(names.Length);
    }

    // Update is called once per frame
    void Update()
    {
        if(beginning && transform.position.y < 15)
        {
            transform.position = new Vector2(0, transform.position.y + 15 * Time.deltaTime);
        }
    }

    public void begin()
    {
        generateProfile();
        beginning = true;
        GetComponent<AudioSource>().Play();
    }

    public bool tableContains(List<int> l,int num)
    {
        for(int o = 0;o < l.Count;o++)
        {
            if (l[o] == num)
            {
                return true;
            }
        }
        return false;
    }
}
