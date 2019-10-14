using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public GameObject tilePrefab;
    Vector3 mousePosition;
    Vector3 worldPosition;

    bool dragging;
    GameObject currentTile;

    bool onX = true;

    LayerMask gridLayer;
    LayerMask matchLayer;

    void checkForMatches(Vector2 pos)
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(pos, Vector2.zero, 100f, matchLayer);
        if (hits.Length > 0)
        {
            for(int i = 0;i < hits.Length;i++)
            {
                hits[i].collider.gameObject.GetComponent<MatchingScript>().checkMatch(onX);
            }
            onX = !onX;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        gridLayer = LayerMask.GetMask("Grid Layer");
        matchLayer = LayerMask.GetMask("Match Layer");
    }

    // Update is called once per frame
    void Update()
    {
        worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition = new Vector3(worldPosition.x, worldPosition.y, 0);

        if (dragging)
        {
            currentTile.transform.position = mousePosition;

            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, 100f, gridLayer);
                if (hit.collider.gameObject.tag == "grid")
                {
                    currentTile.transform.position = hit.collider.gameObject.transform.position;
                    dragging = false;
                    hit.collider.gameObject.SetActive(false);

                    checkForMatches(currentTile.transform.position);
                }
            }
        }
    }

    public void onButtonPressed()
    {
        if (!dragging)
        {
            currentTile = Instantiate(tilePrefab, mousePosition, Quaternion.identity);
            currentTile.GetComponent<TileScript>().isX = onX;
            
            dragging = true;
        }
    }
}
