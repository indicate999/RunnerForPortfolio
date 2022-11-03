using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody _rb;
    [SerializeField] private UI _ui;
    [SerializeField] private SceneLoader _sceneLoader;
    [SerializeField] private SoundEffector _soundEffector;

    [SerializeField] private SpeedSettingsData _speedSettings;

    private bool isKeyControl = false;

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        CheckControl();
    }

    private void FixedUpdate()
    {
        MakeControl();
    }

    private void CheckControl()
    {
        if ((Input.anyKeyDown || Input.touchCount > 0) && !_animator.GetBool("isRun"))
        {
            _animator.SetBool("isRun", true);
            _ui.HideStartPanel();
        }

        if (Input.anyKeyDown && Input.touchCount == 0 && !isKeyControl)
        {
            isKeyControl = true;
        }
        else if (Input.touchCount > 0 && isKeyControl)
        {
            isKeyControl = false;
        }
    }

    private void MakeControl()
    {
        if (isKeyControl)
        {
            _rb.velocity = new Vector3(Input.GetAxis("Horizontal") * _speedSettings.ControlButtonSpeed, 0, _speedSettings.ForwardButtonSpeed);
        }
        else if (Input.touchCount > 0)
        {
            Touch t = Input.GetTouch(0);

            if (t.phase == TouchPhase.Moved)
            {
                _rb.velocity = new Vector3(t.deltaPosition.x * _speedSettings.ControlTouchSpeed, 0, _speedSettings.ForwardTouchSpeed);
            }

            if (t.phase == TouchPhase.Ended)
            {
                _rb.velocity = new Vector3(0, 0, _speedSettings.ForwardTouchSpeed);
            }
        }
    }

    

}
