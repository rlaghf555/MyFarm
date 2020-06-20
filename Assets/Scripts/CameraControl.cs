﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform playerTransform;
    public Vector3 cameraOffset;
    private Camera mainCamera;
    public Transform Camerapos;
    public float rotateSpeed = 10.0f;
    public float zoomSpeed = 10.0f;
    [Range(0.001f, 1.0f)]
    public float SmoothFactor = 0.5f;
    [HideInInspector]
    public bool ismove;
    private float mouseX;
    private float mouseY;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GetComponent<Camera>();
        transform.position = playerTransform.position + cameraOffset;
        ismove = false;
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
    }

    // Update is called once per frame
    void Update()
    {
        Zoom();
        Rotate();
    }
    private void Follow()
    {
        Vector3 dir = playerTransform.forward;
        Vector3 newPos = playerTransform.position + cameraOffset;
        transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);
    }
    private void Zoom()
    {
        float distance = Input.GetAxis("Mouse ScrollWheel") * -1 * zoomSpeed;
        if (distance != 0)
        {
            mainCamera.fieldOfView += distance;
        }
    }
    private void Rotate()
    {
        if (Input.GetMouseButton(0)&&!ismove)
        {
           
            transform.RotateAround(playerTransform.position, playerTransform.right, mouseY * rotateSpeed);
            transform.RotateAround(playerTransform.position, Vector3.down, mouseX* rotateSpeed);
            mouseX = Input.GetAxis("Mouse X");
            mouseY = Input.GetAxis("Mouse Y");
        }
        if (mainCamera.transform.position.y <= 1.5)
        {
            transform.RotateAround(playerTransform.position, playerTransform.right, -Input.GetAxis("Mouse Y") * rotateSpeed);
        }
        mainCamera.transform.LookAt(playerTransform.position);
        //cameraOffset = transform.position - playerTransform.position;

    }
    public void CameraBack()
    {
        transform.position = Vector3.Slerp(transform.position, Camerapos.position, SmoothFactor);

    }
}
