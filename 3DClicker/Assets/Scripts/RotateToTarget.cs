using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class RotateToTarget : MonoBehaviour
{

    [SerializeField]
    private float _mouseSensitivity;

    
    private Camera _camera;

    [SerializeField]
    private Vector3 _recoil;
    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float _yaw;
    private float _pitch;

    [FormerlySerializedAs("minX")] [SerializeField]
    private float _minX;
    [FormerlySerializedAs("maxX")] [SerializeField]
    private float _maxX;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    private void Start()
    {
        _camera = FindObjectOfType<Camera>();
    }

    public void SetRecoil(Vector3 value)
    {
        _recoil += value;
    }
    private void Update()
    {
        _yaw += _mouseSensitivity * Input.GetAxis("Mouse X");
        _pitch -= _mouseSensitivity * Input.GetAxis("Mouse Y");
        

        _pitch = Mathf.Clamp(_pitch, -18 + _recoil.y, 40 + _recoil.y);
        _yaw = Mathf.Clamp(_yaw, _minX - _recoil.x, _maxX - _recoil.x );
        
        _camera.transform.eulerAngles = new Vector3(_pitch + 1 - _recoil.y, _yaw + _recoil.x, 0.0f);
    }
}
