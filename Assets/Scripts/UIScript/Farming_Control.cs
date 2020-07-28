using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public enum BUILD_OBJECT
{
    DIRT_ROW,WHEAT_FIELD
}
public enum FARMING_MODE
{
    DEFAULT,BUILDING,MODIFY
}
public class Farming_Control : MonoBehaviour
{
    private Camera Farming_Camera;
    public GameObject Selected_Object;
    public GameObject[] Build_Prefabs;
    private GameObject objectcheck;
    public GridSetting gridSetting;
    public GameObject build_buttons;
    public GameObject building_object;
    public FARMING_MODE mode;
    public Vector3 button_offset;
    // Start is called before the first frame update
    void Start()
    {
        Farming_Camera= GetComponent<Camera>();
        build_buttons.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (mode == FARMING_MODE.DEFAULT)
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

                    if (hit.collider.tag == "Collectable" || hit.collider.tag == "Grid" || hit.collider.tag == "Building")
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
                    if (objectcheck == hit.collider.gameObject)
                    {
                        if (Selected_Object)
                        {
                            gridSetting.GridReset();                           
                        }
                        Selected_Object = hit.collider.gameObject;

                        if (hit.collider.tag == "Collectable" || hit.collider.tag == "Building")
                        {
                            Debug.Log("Asdf");
                            Select_Grid_Check();
                        }
                        else if (hit.collider.tag == "Grid")
                        {
                            if (Selected_Object.GetComponent<Grid>())
                                Selected_Object.GetComponent<Grid>().Able();
                        }
                    }
                }
            }
        }
        else if(mode == FARMING_MODE.BUILDING)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                //Debug.Log("down");
                Ray ray = Farming_Camera.ScreenPointToRay(Input.mousePosition);
                Debug.Log("Shoot");
                int layermask = 1 << LayerMask.NameToLayer("Grid");
                Physics.Raycast(ray, out hit,10000f,layermask);
                //Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 2);
                Debug.DrawRay(ray.origin, ray.direction*10000, Color.red,5);
                Debug.Log(hit.collider);
                if (hit.collider != null)
                {

                    if (hit.collider.tag == "Grid")
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
                int layermask = 1 << LayerMask.NameToLayer("Grid");
                Physics.Raycast(ray, out hit, 10000f, layermask);
                //Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 2);

                if (hit.collider != null)
                {
                    if (objectcheck == hit.collider.gameObject)
                    {
                        if (Selected_Object)
                        {                           
                            if (Selected_Object.GetComponent<Grid>())
                            {
                                Selected_Object.GetComponent<Grid>().UnSelected();
                            }
                        }
                        Selected_Object = hit.collider.gameObject;

                    if (hit.collider.tag == "Grid")
                        {
                            if (Selected_Object.GetComponent<Grid>())
                            {
                                Selected_Object.GetComponent<Grid>().Able();
                                building_object.transform.position = Selected_Object.transform.parent.position;
                                gridSetting.GridReset();
                                Building_Grid_Check();

                            }
                        }
                    }
                }
            }
            if (building_object)
            {
                build_buttons.SetActive(true);
                build_buttons.transform.position = Farming_Camera.WorldToScreenPoint(building_object.transform.position) + button_offset;
            }
            else
            {
                build_buttons.SetActive(false);

            }
        }
        else if(mode== FARMING_MODE.MODIFY)
        {
            if (Selected_Object)
            {
                build_buttons.SetActive(true);
                build_buttons.transform.position = Farming_Camera.WorldToScreenPoint(Selected_Object.transform.position) + button_offset;

            }
        }
    }

    private void OnEnable()
    {
        if (Selected_Object)
        {
            if(Selected_Object.GetComponent<CollectableObject>())
                 Selected_Object.GetComponent<CollectableObject>().UnSelected();
            if (Selected_Object.GetComponent<Grid>())
                Selected_Object.GetComponent<Grid>().UnSelected();
            Collider[] c = Physics.OverlapBox(Selected_Object.GetComponent<BoxCollider>().center + Selected_Object.transform.position, Selected_Object.GetComponent<BoxCollider>().size / 2);
            foreach (Collider tmp in c)
            {

                if (tmp.GetComponent<Grid>())
                {
                    tmp.GetComponent<Grid>().UnSelected();

                }
            }
            Selected_Object = null;
        }
    }
    private void OnDisable()
    {

        if (Selected_Object)
        {
            Collider[] c = Physics.OverlapBox(Selected_Object.GetComponent<BoxCollider>().center + Selected_Object.transform.position, Selected_Object.GetComponent<BoxCollider>().size / 2);
            foreach (Collider tmp in c)
            {

                if (tmp.GetComponent<Grid>())
                {
                    tmp.GetComponent<Grid>().UnSelected();

                }
                if (tmp.GetComponent<CollectableObject>())
                {
                    tmp.GetComponent<CollectableObject>().UnSelected();

                }
            }
        }
        Selected_Object = null;

    }
    public void FarmBuildSetting(BUILD_OBJECT build_object)
    {
        if (Selected_Object)
        {
            if(Selected_Object.tag == "Grid")
            {
                if (building_object)
                {
                    Destroy(building_object);
                }
               Debug.Log(Selected_Object.transform.parent.position);
                building_object = Instantiate(Build_Prefabs[(int)build_object], Selected_Object.transform.parent.position, Quaternion.identity);
                //newGameobject.transform.SetParent(Selected_Object.transform.parent);
                mode = FARMING_MODE.BUILDING;
                Building_Grid_Check();
            }
        }
    }
    public bool Building_Grid_Check()
    {
        bool value = true;
        Building_Object tmp_build = building_object.GetComponent<Building_Object>();
 
        tmp_build.grid_x = Selected_Object.GetComponent<Grid>().grid_x;
        tmp_build.grid_z = Selected_Object.GetComponent<Grid>().grid_z;
       
        for(int x = 0; x < tmp_build.size_x; x++)
        {
            for(int z = 0; z < tmp_build.size_z; z++)
            {
                if (tmp_build.grid_x + x >= gridSetting.mainArray.Length)
                {
                    value = false;
                    continue;
                }
                if (tmp_build.grid_z + z >= gridSetting.mainArray[tmp_build.grid_x + x].subArray.Length)
                {
                    value = false;
                    continue;
                }
                if (gridSetting.mainArray[tmp_build.grid_x + x].subArray[tmp_build.grid_z + z].GetComponentInChildren<Grid>().buildable)
                    gridSetting.mainArray[tmp_build.grid_x + x].subArray[tmp_build.grid_z + z].GetComponentInChildren<Grid>().Able();
                else
                {
                    gridSetting.mainArray[tmp_build.grid_x + x].subArray[tmp_build.grid_z + z].GetComponentInChildren<Grid>().Disable();
                    value = false;
                }

            }
        }
        return value;
    }
    public bool Select_Grid_Check()
    {
        bool value = true;
        Building_Object tmp_build = Selected_Object.GetComponent<Building_Object>();

        //tmp_build.grid_x = Selected_Object.GetComponent<Grid>().grid_x;
       // tmp_build.grid_z = Selected_Object.GetComponent<Grid>().grid_z;

        for (int x = 0; x < tmp_build.size_x; x++)
        {
            for (int z = 0; z < tmp_build.size_z; z++)
            {
                if (tmp_build.grid_x + x >= gridSetting.mainArray.Length)
                {
                    value = false;
                    continue;
                }
                if (tmp_build.grid_z + z >= gridSetting.mainArray[tmp_build.grid_x + x].subArray.Length)
                {
                    value = false;
                    continue;
                }
                if (gridSetting.mainArray[tmp_build.grid_x + x].subArray[tmp_build.grid_z + z].GetComponentInChildren<Grid>().buildable)
                    gridSetting.mainArray[tmp_build.grid_x + x].subArray[tmp_build.grid_z + z].GetComponentInChildren<Grid>().Able();
                else
                {
                    gridSetting.mainArray[tmp_build.grid_x + x].subArray[tmp_build.grid_z + z].GetComponentInChildren<Grid>().Disable();
                    value = false;
                }

            }
        }
        return value;
    }
    public void Building_Grid_Set()
    {
        bool value = true;
        Building_Object tmp_build = building_object.GetComponent<Building_Object>();

        tmp_build.grid_x = Selected_Object.GetComponent<Grid>().grid_x;
        tmp_build.grid_z = Selected_Object.GetComponent<Grid>().grid_z;

        for (int x = 0; x < tmp_build.size_x; x++)
        {
            for (int z = 0; z < tmp_build.size_z; z++)
            {
                if (tmp_build.grid_x + x >= gridSetting.mainArray.Length)
                {
                    continue;
                }
                if (tmp_build.grid_z + z >= gridSetting.mainArray[tmp_build.grid_x + x].subArray.Length)
                {
                    continue;
                }
                gridSetting.mainArray[tmp_build.grid_x + x].subArray[tmp_build.grid_z + z].GetComponentInChildren<Grid>().buildable = false;
            }
        }
    }
    public void Build_Rotate()
    {
        building_object.transform.Rotate(Vector3.up, 90);
        building_object.GetComponent<Building_Object>().rotation_y = building_object.transform.rotation.eulerAngles.y;
    }

    public void Build_Check()
    {
        if (mode == FARMING_MODE.BUILDING)
        {
            if (Building_Grid_Check())
            {
                Building_Grid_Set();
                building_object.transform.SetParent(Selected_Object.transform.parent);
                build_buttons.SetActive(false);
                building_object = null;
                Selected_Object = null;
                mode = FARMING_MODE.DEFAULT;
            }
        }
        if(mode == FARMING_MODE.MODIFY)
        {

        }
        gridSetting.GridReset();

    }

    public void Build_Cancel()
    {
        if (mode == FARMING_MODE.BUILDING)
        {
            Destroy(building_object);
            build_buttons.SetActive(false);

            mode = FARMING_MODE.DEFAULT;
        }
        if (mode == FARMING_MODE.MODIFY)
        {

        }
        gridSetting.GridReset();
    }
}
