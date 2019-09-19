using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceScript : MonoBehaviour
{
    public float angle = 0;

    // Start is called before the first frame update
    void Start()
    {
        angle = Random.Range(0,360);
    }

    // Update is called once per frame
    void Update()
    {
        angle+=120*Time.deltaTime;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (transform.position.y < -6)
        {
            Destroy(gameObject);
        }
    }
}
