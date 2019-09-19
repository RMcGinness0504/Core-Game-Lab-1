using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainController : MonoBehaviour
{
    public GameObject ball;
    public GameObject[] platforms = new GameObject[7];
    public GameObject platformPrefab;
    public Text scoreText;
    public int score = 0;

    void resetColors()
    {
        for (int i = 0; i < platforms.Length; i++)
        {
            platforms[i].GetComponent<SpriteRenderer>().color = Random.ColorHSV(0.0f, 1.0f, 0.5f, 1.0f, 0.5f, 1.0f);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(ball, new Vector2(Random.Range(-6.0f, 6.0f), 3f),Quaternion.identity);
        for(int i = 0;i < platforms.Length;i++)
        {
            platforms[i] = Instantiate(platformPrefab, new Vector2((float)(2 * i - 6), -4), Quaternion.identity);
        }
        resetColors();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "" + score;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            resetColors();
        }

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0f;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(new Vector3(0, -10, 0));
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg - 90;
        for (int i = 0; i < 10; i++)
        {
            platforms[i].transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }
}
