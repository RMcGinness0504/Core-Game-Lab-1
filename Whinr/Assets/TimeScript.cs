﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = System.DateTime.Now.Hour + ":" +System.DateTime.Now.Minute;
    }
}
