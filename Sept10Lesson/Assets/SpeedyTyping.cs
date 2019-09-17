using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedyTyping : MonoBehaviour
{
	public Text textObj;

    float timer;
    bool GtoH;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (GtoH)
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                timer = 0;
                GtoH = false;
            }
        } else
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                timer = 0;
                GtoH = true;
            }
        }
		timer += Time.deltaTime;

		textObj.text = "" + timer;
    }
}