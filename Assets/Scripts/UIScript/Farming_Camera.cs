using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Farming_Camera : MonoBehaviour
{
    public Transform Camerapos;
    public float speed = 10.0f;
    [Range(0.001f, 1.0f)]
    public float SmoothFactor = 0.5f;
   
    // Start is called before the first frame update
    void Start()
    {
        transform.SetPositionAndRotation(Camerapos.position, Camerapos.rotation);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CameraMove();
    }
    void CameraMove()
    {
        if (Input.touchCount > 0)
        {
            Ray2D ray = new Ray2D(Input.GetTouch(0).position, Vector2.zero);

            RaycastHit2D hitInfo = Physics2D.Raycast(ray.origin, ray.direction);
            // RaycastHit2D can be either true or null, but has an implicit conversion to bool, so we can use it like this
            if (hitInfo.collider != null)
            {
                if (hitInfo.collider.tag == "CameraTouch2")
                {
                    Debug.Log("touch");
                    Vector3 newPos = transform.position;
                    newPos.x += Input.GetTouch(0).deltaPosition.x * (speed * 0.01f);
                    newPos.y = Camerapos.position.y;
                    newPos.z += Input.GetTouch(0).deltaPosition.y * (speed * 0.01f) ;
                   
                    if (newPos.x < -70)
                        newPos.x = -70;
                    if (newPos.x > 80)
                        newPos.x = 80;
                    if (newPos.z < -20)
                        newPos.z = -20;
                    if (newPos.z > 25)
                        newPos.z = 25;
                    transform.position = newPos;
                }
                // Here you can check hitInfo to see which collider has been hit, and act appropriately.
            }

            return;

        }
        if (Input.GetMouseButton(0))
        {
            Ray2D ray = new Ray2D(Input.mousePosition, Vector2.zero);

            RaycastHit2D hitInfo = Physics2D.Raycast(ray.origin, ray.direction);
            // RaycastHit2D can be either true or null, but has an implicit conversion to bool, so we can use it like this
            if (hitInfo.collider != null)
            {
                if (hitInfo.collider.tag == "CameraTouch2")
                {
                    Vector3 newPos = transform.position;
                    newPos.x += Input.GetAxis("Mouse X") * speed;
                    newPos.z -= Input.GetAxis("Mouse X") * speed;
                    newPos.y = Camerapos.position.y;
                
                    newPos.x += Input.GetAxis("Mouse Y") * speed;
                    newPos.z += Input.GetAxis("Mouse Y") * speed;
                    
                    if (newPos.x < -70)
                        newPos.x = -70;
                    if (newPos.x > 80)
                        newPos.x = 80;
                    if (newPos.z < -20)
                        newPos.z = -20;
                    if (newPos.z > 25)
                        newPos.z = 25;
                    transform.position = newPos;
                    // transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);
                   
                }
                // Here you can check hitInfo to see which collider has been hit, and act appropriately.
            }

            return;

        }
    }

    private void OnEnable()
    {
    }
}
