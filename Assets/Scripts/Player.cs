using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Player : MonoBehaviour
{
    private Animator _anim;
    [SerializeField] CinemachineVirtualCameraBase _Camera;
    private CharacterController _controller;
    private Vector3 _playerVelocity;
    private float _playerSpeed = 4.0f;
    private float _speed = 3.0f;
    private Rigidbody _rb;
    public float currentHealth;
    public float maxHealth = 100f;
    
    private void Awake()
    {
        currentHealth = maxHealth;

        _controller = GetComponent<CharacterController>();
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        PlayerMovement();
        MouseController();
    }
    private void PlayerMovement()
    {
        _playerVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _playerVelocity = transform.TransformDirection(_playerVelocity);
        _controller.Move(_playerVelocity * Time.deltaTime * _playerSpeed);

        if (_playerVelocity == Vector3.zero)
        {
            _anim.SetFloat("Speed", 0);
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            _anim.SetFloat("Speed", 2);
        }
        else
        {
            _anim.SetFloat("Speed", 4);
        }
    }
    private void MouseController()
    {
        float X = Input.GetAxis("Mouse X") * _speed;
        float Y = Input.GetAxis("Mouse Y") * _speed;
        transform.Rotate(0, X, 0);
        if (_Camera.transform.eulerAngles.x + (-Y) > 80 && _Camera.transform.eulerAngles.x + (-Y) < 200)
        { 

        }
        else
        {
            _Camera.transform.RotateAround(transform.position, _Camera.transform.right, -Y);
        }  
    }
    public void TakeDamage(float damage = 5f)
    {
        currentHealth -=damage;
    }
}
