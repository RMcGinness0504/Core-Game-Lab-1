using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public void buttonPressed()
    {
        SceneManager.LoadScene("Scene2", LoadSceneMode.Single);
    }
}
