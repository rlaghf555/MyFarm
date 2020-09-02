using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMoveByJoystick : MonoBehaviour
{
    public float moveSpeed;
    public float rotateSpeed;
    public FixedJoystick fixedJoystick;
    public FloatingJoystick floatingJoystick;
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
        //fixedJoystick = FindObjectOfType<FixedJoystick>();
    }
    public void FixedUpdate()
    {
        RotateF();
        MoveF();
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
    private void MoveF()
    {
        Vector3 moveDistance =
           floatingJoystick.Vertical * transform.forward * moveSpeed * Time.deltaTime;
        if(floatingJoystick.Vertical!=0)
        playerRigidBody.MovePosition(playerRigidBody.position+new Vector3(0,-0.03f,0) + moveDistance);
        else
        playerRigidBody.MovePosition(playerRigidBody.position + moveDistance);
            playerAnimator.SetFloat("Move", floatingJoystick.Vertical);
        if (floatingJoystick.Vertical != 0)
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
    private void RotateF()
    {
        playerRigidBody.rotation = playerRigidBody.rotation * Quaternion.Euler(0, floatingJoystick.Horizontal * rotateSpeed, 0f);
    }
    private void OnDisable()
    {
        playerAnimator.SetFloat("Move", 0);
        cameraControl.CameraBack();
    }
}