using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScript : MonoBehaviour
{
    Vector3 pos;
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 pos = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 0));
        transform.position = new Vector2(pos.x, pos.y);
    }
}
