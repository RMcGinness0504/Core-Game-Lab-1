using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    int score = 0;

    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void updateScoreText(int z)
    {
        scoreText.text = "" + z;
    }

    public void ButtonClicked()
    {
        score++;
        updateScoreText(score);
    }

    public void ButtonClickedDecrease()
    {
        score--;
        updateScoreText(score);
    }
}
