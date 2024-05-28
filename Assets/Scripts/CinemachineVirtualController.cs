using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemachineVirtualController : MonoBehaviour
{
    private Animator _anim;
    private bool _isFollowCam = true;
    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            SwitchCamera();
        }
    }

    private void SwitchCamera()
    {
        if (_isFollowCam)
        {
            _anim.Play("FollowCam");
        }
        else
        {
            _anim.Play("AimCam");
        }
        _isFollowCam = !_isFollowCam;
    }
}