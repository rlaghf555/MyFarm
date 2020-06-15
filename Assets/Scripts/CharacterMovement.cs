using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AI;

public class CharacterMovement : MonoBehaviour
{
    private NavMeshAgent pathfinder;
    private Vector3 target;
    private Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        pathfinder = GetComponent<NavMeshAgent>();
        camera = FindObjectOfType<Camera>();
        target = new Vector3();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))  // 마우스가 클릭 되면
        {
            Debug.Log("마우스 입력");
            Vector3 mos = Input.mousePosition;
            mos.z = camera.farClipPlane; // 카메라가 보는 방향과, 시야를 가져온다.

            Vector3 dir = camera.ScreenToWorldPoint(mos);
            // 월드의 좌표를 클릭했을 때 화면에 자신이 보고있는 화면에 맞춰 좌표를 바꿔준다.

            NavMeshHit nhit;
            NavMesh.SamplePosition(dir, out nhit, 10, NavMesh.AllAreas);
            pathfinder.destination = nhit.position;
        }
        
    }
}
