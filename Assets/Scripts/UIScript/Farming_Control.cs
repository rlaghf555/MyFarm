using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farming_Control : MonoBehaviour
{
    private Camera Farming_Camera;
    public GameObject Selected_Object;
    private GameObject objectcheck;
    // Start is called before the first frame update
    void Start()
    {
        Farming_Camera= GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            //Debug.Log("down");
            Ray ray = Farming_Camera.ScreenPointToRay(Input.mousePosition);

            Physics.Raycast(ray, out hit);
            //Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 2);

            if (hit.collider != null)
            {

                if (hit.collider.tag == "Collectable")
                {
                    objectcheck = hit.collider.gameObject;
                }

            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit hit;
            //Debug.Log("down");
            Ray ray = Farming_Camera.ScreenPointToRay(Input.mousePosition);

            Physics.Raycast(ray, out hit);
            //Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 2);

            if (hit.collider != null)
            {

                if (hit.collider.tag == "Collectable")
                {
                    if (objectcheck == hit.collider.gameObject)
                    {
                        //Debug.Log("hit");
                        if (Selected_Object)
                        {
                            Selected_Object.GetComponent<CollectableObject>().UnSelected();
                            Selected_Object.GetComponentInParent<SpriteRenderer>().color = Color.gray;

                        }
                        Selected_Object = hit.collider.gameObject;
                        Selected_Object.GetComponent<CollectableObject>().Selected();
                        Selected_Object.GetComponentInParent<SpriteRenderer>().color = Color.red;
                    }
                }

            }
        }
    }

    private void OnEnable()
    {
        if (Selected_Object)
        {
            Selected_Object = null;
            Selected_Object.GetComponent<CollectableObject>().UnSelected();
        }
    }
}
