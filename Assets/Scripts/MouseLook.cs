using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private Transform _playerBody;
    [SerializeField] private Transform _playerHead;
    float _xRotation = 0f;

    [SerializeField] float _mouseSens;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

  
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * _mouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSens * Time.deltaTime;

        _playerBody.Rotate(Vector3.up * mouseX);

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);


    }
}
