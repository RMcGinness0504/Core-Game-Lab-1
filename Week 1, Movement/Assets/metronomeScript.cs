using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class metronomeScript : MonoBehaviour
{

    public AudioSource aud;
    public AnimationClip metAnimation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
//        metAnimation.time = (float)(aud.time % 0.8);
    }
}
