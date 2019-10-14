using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationSpeedSlider : MonoBehaviour
{
    public Slider mySlider;
    Animator anim;

    float sliderValue;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        sliderValue = mySlider.value;
        anim.speed = sliderValue;
    }

    public void myAnimationEventFunction()
    {
        Debug.Log("UwU");
    }
}
