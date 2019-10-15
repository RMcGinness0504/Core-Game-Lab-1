using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    public float speed = 1f;

    public static GameControllerScript reference;

    private void Awake()
    {
        if (reference == null)
        {
            reference = this;
        } else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
}
