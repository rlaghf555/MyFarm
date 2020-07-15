using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform playerTransform;
    public Transform lookat;
    public Vector3 cameraOffset;
    private Camera mainCamera;
    public Transform Camerapos;
    public RectTransform cameraInputPos;
    public Canvas canvas;
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

        if (Input.touchCount >0&&!ismove)
        {
            Ray2D ray = new Ray2D(Input.GetTouch(0).position, Vector2.zero);

            RaycastHit2D hitInfo = Physics2D.Raycast(ray.origin,ray.direction);
            // RaycastHit2D can be either true or null, but has an implicit conversion to bool, so we can use it like this
            if (hitInfo.collider!=null)
            {
                if (hitInfo.collider.tag == "CameraTouch")
                {

                    transform.RotateAround(lookat.position, Vector3.down, Input.GetTouch(0).deltaPosition.x * rotateSpeed*0.1f);
                    transform.RotateAround(lookat.position, playerTransform.right, Input.GetTouch(0).deltaPosition.y * rotateSpeed*0.1f);
                    if (mainCamera.transform.position.y <= 1.5)
                    {
                        transform.RotateAround(lookat.position, playerTransform.right, -Input.GetTouch(0).deltaPosition.y * rotateSpeed * 0.1f);

                    }
                }
                // Here you can check hitInfo to see which collider has been hit, and act appropriately.
            }
            mainCamera.transform.LookAt(lookat.position);

            return;

        }

        if (Input.GetMouseButton(0) && !ismove)
        {

            Ray2D ray = new Ray2D(Input.mousePosition,Vector2.zero);

            RaycastHit2D hitInfo = Physics2D.Raycast(ray.origin, ray.direction);
            // RaycastHit2D can be either true or null, but has an implicit conversion to bool, so we can use it like this
            if (hitInfo.collider != null)
            {

                if (hitInfo.collider.tag == "CameraTouch")
                {

                    transform.RotateAround(lookat.position, Vector3.down, -mouseX * rotateSpeed);
                    transform.RotateAround(lookat.position, playerTransform.right, -mouseY * rotateSpeed);
                    if (mainCamera.transform.position.y <= 1.5)
                    {
                        transform.RotateAround(lookat.position, playerTransform.right, mouseY * rotateSpeed);

                    }
                }
                mouseX = Input.GetAxis("Mouse X");
                mouseY = Input.GetAxis("Mouse Y");
            }



        }
        mainCamera.transform.LookAt(lookat.position);



    }
    public void CameraBack()
    {
        transform.position = Vector3.Slerp(transform.position, Camerapos.position, SmoothFactor);

    }
}
