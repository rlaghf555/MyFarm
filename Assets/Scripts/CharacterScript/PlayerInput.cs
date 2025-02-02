﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 플레이어 캐릭터를 조작하기 위한 사용자 입력을 감지
// 감지된 입력값을 다른 컴포넌트들이 사용할 수 있도록 제공
public class PlayerInput : MonoBehaviour {
    public string moveAxisName = "Vertical"; // 앞뒤 움직임을 위한 입력축 이름
    public string rotateAxisName = "Horizontal"; // 좌우 회전을 위한 입력축 이름
    public Camera mainCamera;
    [HideInInspector]
    public CameraControl cameraControl;
    private Animator playerAnimator;

    private void Start()
    {
        cameraControl = mainCamera.GetComponent<CameraControl>();
        playerAnimator = GetComponent<Animator>();

    }
    // 값 할당은 내부에서만 가능
    public float move { get; private set; } // 감지된 움직임 입력값
    public float rotate { get; private set; } // 감지된 회전 입력값
    public bool fire { get; private set; } // 감지된 발사 입력값
    public bool reload { get; private set; } // 감지된 재장전 입력값

    // 매프레임 사용자 입력을 감지
    private void Update() {
      

        // move에 관한 입력 감지
        move = Input.GetAxis(moveAxisName);
        if(move != 0)
        {
            cameraControl.CameraBack();
        }
        // rotate에 관한 입력 감지
        rotate = Input.GetAxis(rotateAxisName);
    }
    private void OnDisable()
    {
        move = 0;
        rotate = 0;
        cameraControl.CameraBack();
    }
    public void Axe_Button()
    {
        
        playerAnimator.SetTrigger("Ax");

    } 
    public void Spade_Button()
    {
        
        playerAnimator.SetTrigger("Digging");

    }
    public void Farm_Button()
    {

    }
}