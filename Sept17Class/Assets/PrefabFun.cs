using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabFun : MonoBehaviour
{
    public GameObject platformP;

    Vector3 mP;

    float timer = 0;
    static float interval = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(platformP, new Vector3(0,0,0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= interval)
        {
            timer = 0;

            //Vector3 worldPos = new Vector3(Random.Range(-7f,7f),8,0f);
            Vector3 worldPos = new Vector3(0, 0, 0);

            GameObject g;
            g = Instantiate(platformP,  worldPos, Quaternion.identity);
            float width = Random.Range(1f, 8f);
            g.transform.localScale = new Vector3(width, g.transform.localScale.y, 1f);
            g.GetComponent<PlatformScript>().speed = Random.Range(1, 5);
        }
    }
}
