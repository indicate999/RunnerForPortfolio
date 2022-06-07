using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;

    public float forwardSpeedForButton;
    public float buttonSpeed;

    public float forwardSpeedForTouch;
    public float touchSpeed;

    private bool isButtonControl = false;

    private int RingNum = 0;

    public GameObject StartPanel;
    public GameObject RestartPanel;
    public Text RingNumText;

    public SoundEffector soundEffector;

    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown || Input.touchCount > 0)
        {
            if (!animator.GetBool("isRun"))
            {
                animator.SetBool("isRun", true);
                StartPanel.SetActive(false);
            }
        }

        if (Input.anyKeyDown)
            isButtonControl = true;
    }

    private void FixedUpdate()
    {
        if (isButtonControl)
        {
            rb.velocity = new Vector3(Input.GetAxis("Horizontal") * buttonSpeed, 0, forwardSpeedForButton);
        }

        if (Input.touches.Length > 0)
        {
            Touch t = Input.GetTouch(0);

            if (t.phase == TouchPhase.Moved)
            {
                rb.velocity = new Vector3(t.deltaPosition.x * touchSpeed, 0, forwardSpeedForTouch);
            }

            if (t.phase == TouchPhase.Ended)
            {
                rb.velocity = new Vector3(0, 0, forwardSpeedForTouch);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ring")
        {
            soundEffector.PlayRingSound();
            RingNum++;
            RingNumText.text = RingNum.ToString();
            other.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Spike")
        {
            soundEffector.PlaySpikeSound();
            Time.timeScale = 0;
            RestartPanel.SetActive(true);
        }
    }

}
