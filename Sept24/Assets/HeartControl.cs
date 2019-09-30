using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartControl : MonoBehaviour
{
    public Toggle heartToggle;
    public Animator a;

    // Start is called before the first frame update
    void Start()
    {
        a = GetComponent<Animator>();
    }

    public void onToggle()
    {
        a.SetBool("full", heartToggle.isOn);
    }
}
