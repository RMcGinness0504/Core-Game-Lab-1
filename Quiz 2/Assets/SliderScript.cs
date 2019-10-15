using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    public Text buttonText;

    public void sliderChanged()
    {
        buttonText.text = "" + GetComponent<Slider>().value;
        GameControllerScript.reference.gameObject.GetComponent<GameControllerScript>().speed = GetComponent<Slider>().value;
    }
}
