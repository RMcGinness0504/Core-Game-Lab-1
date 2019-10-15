using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SquareScript : MonoBehaviour
{
    bool warningShown = true;

    public Camera mainCamera;
    public Text timerText;
    float speed;
    float timer = 5f;

    Vector2 mousePosition;
    Vector2 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        speed = GameControllerScript.reference.gameObject.GetComponent<GameControllerScript>().speed;
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        targetPosition = mainCamera.ScreenToWorldPoint(mousePosition);
        transform.position = Vector2.MoveTowards(gameObject.transform.position, targetPosition, speed * Time.deltaTime);

        if (warningShown)
        {
            if (Vector2.Distance(targetPosition, gameObject.transform.position) < 1.5)
            {
                warningShown = false;
            }
        } else
        {
            timerText.text = "" + timer;
        }

        RaycastHit2D rayHit = Physics2D.Raycast(targetPosition, Vector2.zero, 100f);
        if (rayHit.collider != null)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0)
        {
            SceneManager.LoadScene("Scene3", LoadSceneMode.Single);
        }
    }
}
