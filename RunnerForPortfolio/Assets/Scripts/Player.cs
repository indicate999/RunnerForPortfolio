using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;
    private Main main;
    private SoundEffector soundEffector;

    //When controlled using the keys and a touch on a smartphone, the character will have a different speed
    [SerializeField] private float forwardButtonSpeed;
    [SerializeField] private float controlButtonSpeed;

    [SerializeField] private float forwardTouchSpeed;
    [SerializeField] private float controlTouchSpeed;

    private bool isKeyControl = false;

    void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        main = GameObject.FindGameObjectWithTag("Main").GetComponent<Main>();
        soundEffector = GameObject.FindGameObjectWithTag("SoundEffector").GetComponent<SoundEffector>();
    }

    void Update()
    {
        //When you press any key or make a touch, the running animation starts
        if ((Input.anyKeyDown || Input.touchCount > 0) && !animator.GetBool("isRun"))
        {
            animator.SetBool("isRun", true);
            main.StartPanel.SetActive(false);
        }

        //If any key is pressed, then control becomes through the keys
        if (Input.anyKeyDown && Input.touchCount == 0 && !isKeyControl)
        {
            isKeyControl = true;
        }
        else if (Input.touchCount > 0 && isKeyControl)
        {
            isKeyControl = false;
        }
            
    }

    private void FixedUpdate()
    {
        if (isKeyControl)
        {
            rb.velocity = new Vector3(Input.GetAxis("Horizontal") * controlButtonSpeed, 0, forwardButtonSpeed);
        }
        else if (Input.touchCount > 0)
        {
            Touch t = Input.GetTouch(0);

            //During the movement phase of the touch, the velocity along the x-axis changes depending on the control of the touch
            if (t.phase == TouchPhase.Moved)
            {
                rb.velocity = new Vector3(t.deltaPosition.x * controlTouchSpeed, 0, forwardTouchSpeed);
            }

            //With the phase of the end of the touch, the velocity along the x-axis does not change
            if (t.phase == TouchPhase.Ended)
            {
                rb.velocity = new Vector3(0, 0, forwardTouchSpeed);
            }
        }
    }

    //When the ring is triggered, the player gets a point, the score value is updated in the ui element
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ring")
        {
            soundEffector.PlayRingSound();
            main.scoreCount++;
            main.UpdateScore();
            other.gameObject.SetActive(false);
        }
    }

    //When the spike is colliding, the player loses, time stops and the restart panel is activated
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Spike")
        {
            soundEffector.PlaySpikeSound();
            Time.timeScale = 0;
            main.RestartPanel.SetActive(true);
        }
    }

}
