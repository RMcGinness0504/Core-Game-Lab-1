using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator animator;

    public float verticalSpeed;
    public GameObject[] pipes = new GameObject[6];
    public GameObject[] wheels = new GameObject[6];

    public GameObject cameraObject;

    public Sprite pipe;

    public AudioClip music;

    public AudioClip jumpSound;
    public AudioClip bigJumpSound;
    public AudioClip dieSound;

    public AudioSource audSource;
    public AudioSource soundSource;

    public static float rhythmTimerMax = 0.8f;
    public float rhythmTimer = rhythmTimerMax;

    private float angle = 0.0f;

    public bool playerDead;

    public int collidesWithPipe(float y)
    {
        if (playerDead == true)
        {
            return -1;
        }

        for (int i = 0; i < pipes.Length; i++)
        {
            if (y > pipes[i].transform.position.y - 0.2 && y < pipes[i].transform.position.y + 0.9)
            {
                return i;
            }
        }
        return -1;
    }

    public int collidesWithHandle(float x,float y)
    {
        if (playerDead == true)
        {
            return -1;
        }

        for (int i = 0; i <= 4; i++)
        {
            if (y > pipes[i].transform.position.y - 0.9 && y < pipes[i].transform.position.y + 0.9)
            {
                if (x > wheels[i+1].transform.position.x - 0.6 && x < wheels[i+1].transform.position.x + 0.6)
                {
                    return i;
                } else
                {

                }
            }
        }
        return -1;
    }

    private int collide = -1;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < pipes.Length; i++)
        {
            pipes[i].transform.position = new Vector2(0, (float)(0.16 + 4 * i));
            wheels[i].transform.position = new Vector2(Random.Range(-9,-9), pipes[i].transform.position.y);
        }
        animator = this.GetComponent<Animator>();

        audSource.clip = music;
        audSource.Play();

        soundSource.clip = jumpSound;
    }

    // Update is called once per frame
    void Update()
    {
        rhythmTimer = (float)(audSource.time % 0.8);
        if (rhythmTimer > 0.75 || rhythmTimer < 0.05)
        {
        }

        for (int i = 0; i < pipes.Length; i++)
        {
            if (pipes[i].transform.position.y + 4 < transform.position.y)
            {

                wheels[0].transform.position = wheels[1].transform.position;
                wheels[1].transform.position = wheels[2].transform.position;
                wheels[2].transform.position = wheels[3].transform.position;
                wheels[3].transform.position = wheels[4].transform.position;
                wheels[4].transform.position = wheels[5].transform.position;
                wheels[5].transform.position = new Vector2(Random.Range(-3, 3), pipes[5].transform.position.y);
                for (i = 0; i < pipes.Length; i++)
                {
                    pipes[i].transform.position = new Vector2(0, (float)(pipes[i].transform.position.y + 4));
                }
            }
        }

        if (cameraObject.GetComponent<CameraControl>().introCameraTimer <= 0)
        {
            if (Input.GetKey(KeyCode.A) && verticalSpeed == 0)
            {
                animator.SetInteger("state", 1);
                if (transform.position.x > -2.9)
                {
                    transform.position = new Vector2((float)(transform.position.x - 0.015), transform.position.y);
                }
            } else if (Input.GetKey(KeyCode.D) && verticalSpeed == 0)
            {
                animator.SetInteger("state", 2);
                if (transform.position.x < 2.9)
                {
                    transform.position = new Vector2((float)(transform.position.x + 0.015), transform.position.y);
                }
            }
            else if (Input.GetKey(KeyCode.W) && verticalSpeed == 0)
            {
                animator.SetInteger("state", 0);
                if (rhythmTimer > 0.77 || rhythmTimer < 0.03)
                {
                    verticalSpeed = (float)0.78;
                    soundSource.clip = bigJumpSound;
                }
                else
                {
                    verticalSpeed = (float)0.44;
                    soundSource.clip = jumpSound;
                }
                soundSource.Play();
            } else
            {
                animator.SetInteger("state", 0);
            }
        }

        if (verticalSpeed != 0)
        {
            if (verticalSpeed < 0)
            {
                int collide = collidesWithPipe((float)(transform.position.y));
                if (collide > -1)
                {
                    verticalSpeed = 0;
                    transform.position = new Vector2(transform.position.x, (float)(pipes[collide].transform.position.y + 0.9));
                }
            }

            if (verticalSpeed != 0)
            {
                transform.position = new Vector2(transform.position.x, (float)(transform.position.y + (0.23*verticalSpeed)));
            }
            
           if (verticalSpeed > 0)
            {

                int collide = collidesWithHandle((float)(transform.position.x), (float)(transform.position.y));
                Debug.Log(collide);

                verticalSpeed = (float)(verticalSpeed * 0.98);
                if (verticalSpeed < 0.05)
                {
                    verticalSpeed = (float)(-0.05);
                }

                if (collide >= 0)
                {
                    verticalSpeed = (float)(-0.05);
                }
            } else if (verticalSpeed < 0)
            {
                verticalSpeed = (float)(verticalSpeed * 1.01);
            }
        }

        if (playerDead == true)
        {
            if (audSource.isPlaying == true)
            {
                audSource.Stop();
                soundSource.clip = dieSound;
                soundSource.Play();
            }
            angle = angle + 2;
            animator.SetInteger("state", 3);
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}