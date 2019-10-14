using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stampScript : MonoBehaviour
{
    public int stampVal;

    private void OnMouseDown()
    {
        GameObject.FindGameObjectWithTag("file").gameObject.GetComponent<FileScript>().stamp = stampVal;
        GameObject.FindGameObjectWithTag("file").gameObject.GetComponent<FileScript>().updateStamp();
    }
}
