using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // 앞뒤 움직임의 속도
    public float rotateSpeed = 180f; // 좌우 회전 속도
    private NavMeshAgent agent;
    private Animator playerAnimator;
    private PlayerInput playerInput;
    private Rigidbody playerRigidbody;
    public Transform objectPivot;
    public Transform leftHandMount;
    public Transform RightHandMount;
    private bool dig;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        playerAnimator = GetComponent<Animator>();
        playerInput = GetComponent<PlayerInput>();
        playerRigidbody = GetComponent<Rigidbody>();
        dig = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetMouseButtonUp(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                transform.LookAt(hit.point);
                agent.SetDestination(hit.point);
                playerAnimator.SetBool("Walking", true);
                agent.isStopped = false;
            }


        }

        if (agent.remainingDistance <= 0.2f && agent.velocity.magnitude >= 0.2f)
        {
            playerAnimator.SetBool("Walking", false);
        }
        */
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerAnimator.SetTrigger("Digging");
            dig = true;
        }
    }

    private void FixedUpdate()
    {
        Rotate();
        Move();
        playerAnimator.SetFloat("Move", playerInput.move);

    }
    // 입력값에 따라 캐릭터를 앞뒤로 움직임
    private void Move()
    {
        // 상대적으로 이동할 거리 계산
        Vector3 moveDistance =
            playerInput.move * transform.forward * moveSpeed * Time.deltaTime;
        // 리지드바디를 통해 게임 오브젝트 위치 변경
        playerRigidbody.MovePosition(playerRigidbody.position + moveDistance);
    }

    // 입력값에 따라 캐릭터를 좌우로 회전
    private void Rotate()
    {
        // 상대적으로 회전할 수치 계산
        float turn =
            playerInput.rotate * rotateSpeed * Time.deltaTime;
        // 리지드바디를 통해 게임 오브젝트 회전 변경
        playerRigidbody.rotation = playerRigidbody.rotation * Quaternion.Euler(0, turn, 0f);
    }
    private void OnAnimatorIK(int layerIndex)
    {
        if (!dig)
            return;
        objectPivot.position = playerAnimator.GetIKHintPosition(AvatarIKHint.RightElbow);
      playerAnimator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1.0f);
      playerAnimator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1.0f);
      
      playerAnimator.SetIKPosition(AvatarIKGoal.LeftHand, leftHandMount.position);
      playerAnimator.SetIKRotation(AvatarIKGoal.LeftHand, leftHandMount.rotation);

       //playerAnimator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1.0f);
       //playerAnimator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1.0f);
       //
       //playerAnimator.SetIKPosition(AvatarIKGoal.RightHand, RightHandMount.position);
       //playerAnimator.SetIKRotation(AvatarIKGoal.RightHand, RightHandMount.rotation);


    }
}
