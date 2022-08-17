using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
   [SerializeField] private CharacterController _controller;
    [SerializeField] private float _speed;
    [SerializeField] private float _speedBoost;
    [SerializeField] private float _normalSpeed;
    [SerializeField] private float _gravity;
    [SerializeField] private float _jumpHeight;
    [SerializeField] private float _groundDistance;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private Transform _groundCheck;
    Vector3 _velocity;
    bool _isGrounded;

    

    
    void Update()
    {
        _isGrounded = Physics.CheckSphere(_groundCheck.position, _groundDistance, _groundMask);
        if (_isGrounded && _velocity.y < 0)
            _velocity.y = 0;
        


        float xMove = Input.GetAxis("Horizontal");
        float zMove = Input.GetAxis("Vertical");

        Vector3 move = transform.right * xMove + transform.forward * zMove;
        _controller.Move(move * _speed * Time.deltaTime);

        _velocity.y += _gravity * Time.deltaTime;
        _controller.Move(_velocity * Time.deltaTime);

        if (_isGrounded && Input.GetButtonDown("Jump"))
          _velocity.y = Mathf.Sqrt(_jumpHeight * _gravity * -2f);

        if (Input.GetKey("left shift"))
            _speed = _speedBoost;
        else
            _speed = _normalSpeed;

        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene(1);
        

    }
}
