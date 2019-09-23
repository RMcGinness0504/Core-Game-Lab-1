using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    public Sprite[] animationFrames = new Sprite[4]; //replace 4 with number of frames
                                                     //after compiling, you will be able to add sprites from the inspector

    public static float animationTimerMax = 0.2f; //The time in seconds a frame lasts
    float animationTimer = animationTimerMax;

    public int animationFrame = 0;
    public static int animationFrameMax;

    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
         animationFrameMax = animationFrames.Length - 1;

         sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        animationTimer -= Time.deltaTime;
        if (animationTimer <= 0)
        {
            animationTimer += animationTimerMax;
            animationFrame++;
            if (animationFrame > animationFrameMax)
            {
                animationFrame = 0;
            }

            sr.sprite = animationFrames[animationFrame];
        }
    }
}
