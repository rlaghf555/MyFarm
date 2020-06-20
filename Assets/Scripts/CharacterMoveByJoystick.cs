using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMoveByJoystick : MonoBehaviour
{
    public float moveSpeed;
    public float rotateSpeed;
    public FixedJoystick fixedJoystick;
    private Rigidbody playerRigidBody;
    public Transform player;
    private Animator playerAnimator;
    public Camera mainCamera;
    private CameraControl cameraControl;
    private void Start()
    {
        playerAnimator = player.GetComponent<Animator>();
        playerRigidBody = player.GetComponent<Rigidbody>();
        cameraControl = mainCamera.GetComponent<CameraControl>();
    }
    public void FixedUpdate()
    {
        Rotate();
        Move();
    }
    private void Move()
    {
        Vector3 moveDistance =
           fixedJoystick.Vertical * transform.forward * moveSpeed * Time.deltaTime;
        playerRigidBody.MovePosition(playerRigidBody.position + moveDistance);
        playerAnimator.SetFloat("Move", fixedJoystick.Vertical);
        if (fixedJoystick.Vertical != 0)
        {
            cameraControl.CameraBack();
            cameraControl.ismove = true;
        }
        else cameraControl.ismove = false;
    }
    private void Rotate()
    {
        playerRigidBody.rotation = playerRigidBody.rotation * Quaternion.Euler(0, fixedJoystick.Horizontal*rotateSpeed, 0f);
    }
    private void OnDisable()
    {
        playerAnimator.SetFloat("Move", 0);
        cameraControl.CameraBack();
    }
}