using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[SerializeField]
public enum BUILD_OBJECT
{
    DIRT_ROW,WHEAT_FIELD,TREE_APPLE,TREE_APRICOT,TREE_CHERRY,TREE_LEMON,
    TREE_ORRANGE,TREE_PEACH,TREE_PEAR,TREE_PLUM
}
public enum FARMING_MODE
{
    DEFAULT,BUILDING,MODIFY,PLANTING
}
public class Farming_Control : MonoBehaviour
{
    private Camera Farming_Camera;
    public GameObject selected_object;
    public GameObject[] Build_Prefabs;
    private GameObject objectcheck;
    public GridSetting gridSetting;
    public GameObject build_buttons;
    public GameObject building_object;
    public FARMING_MODE mode;
    public Vector3 button_offset;
    public bool planting_ready = false;
    public Image Ground_Button;
    public Image Crops_Button;
    public Image Building_Button;
    public Image Tree_Button;
    public Color selected_Color;
    public Color unselected_Color;
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
                if (EventSystem.current.IsPointerOverGameObject())
                    return;
                RaycastHit hit;
                //Debug.Log("down");
                Ray ray = Farming_Camera.ScreenPointToRay(Input.mousePosition);
               
                Physics.Raycast(ray, out hit);
                //Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 2);

                if (hit.collider != null)
                {

                    if (hit.collider.tag == "Collectable" || hit.collider.tag == "Grid" || hit.collider.tag == "Building"|| hit.collider.tag == "Dirt")
                    {
                        objectcheck = hit.collider.gameObject;
                    }

                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                if (EventSystem.current.IsPointerOverGameObject())
                    return;
                RaycastHit hit;
                //Debug.Log("down");
                Ray ray = Farming_Camera.ScreenPointToRay(Input.mousePosition);

                Physics.Raycast(ray, out hit);
                Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 2);

                if (hit.collider != null)
                {
                    if (objectcheck == hit.collider.gameObject)
                    {
                        if (selected_object)
                        {
                            gridSetting.GridReset();                           
                        }
                        selected_object = hit.collider.gameObject;

                        if (hit.collider.tag == "Collectable" || hit.collider.tag == "Building" || hit.collider.tag == "Dirt")
                        {
                            Debug.Log(hit.collider);
                            building_object = hit.collider.gameObject;
                            Select_Grid_Check();
                            mode = FARMING_MODE.MODIFY;
                        }
                        else if (hit.collider.tag == "Grid")
                        {
                            if (selected_object.GetComponent<Grid>())
                                selected_object.GetComponent<Grid>().Able();
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
                if (EventSystem.current.IsPointerOverGameObject())
                    return;
                RaycastHit hit;
                //Debug.Log("down");
                Ray ray = Farming_Camera.ScreenPointToRay(Input.mousePosition);
                int layermask = 1 << LayerMask.NameToLayer("Grid");
                Physics.Raycast(ray, out hit, 10000f, layermask);
                Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 2);

                if (hit.collider != null)
                {
                    if (objectcheck == hit.collider.gameObject)
                    {
                        if (selected_object)
                        {                           
                            if (selected_object.GetComponent<Grid>())
                            {
                                selected_object.GetComponent<Grid>().UnSelected();
                            }
                        }
                        selected_object = hit.collider.gameObject;

                    if (hit.collider.tag == "Grid")
                        {
                            if (selected_object.GetComponent<Grid>())
                            {
                                selected_object.GetComponent<Grid>().Able();
                                building_object.transform.position = selected_object.transform.parent.position;

                                gridSetting.GridReset();
                                Building_Grid_Check();

                            }
                        }
                    }
                }
            }
                build_buttons.transform.position = Farming_Camera.WorldToScreenPoint(building_object.transform.position+building_object.GetComponent<BoxCollider>().center) + button_offset;
            }
        else if(mode== FARMING_MODE.MODIFY)
        {

            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                //Debug.Log("down");
                Ray ray = Farming_Camera.ScreenPointToRay(Input.mousePosition);
                Debug.Log("Shoot");
                int layermask = 1 << LayerMask.NameToLayer("Grid");
                Physics.Raycast(ray, out hit, 10000f, layermask);
                //Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 2);
                Debug.DrawRay(ray.origin, ray.direction * 10000, Color.red, 5);
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
                if (EventSystem.current.IsPointerOverGameObject())
                    return;
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
                        if (selected_object)
                        {
                            if (selected_object.GetComponent<Grid>())
                            {
                                selected_object.GetComponent<Grid>().UnSelected();
                            }
                        }
                        selected_object = hit.collider.gameObject;

                        if (hit.collider.tag == "Grid")
                        {
                            if (selected_object.GetComponent<Grid>())
                            {
                                selected_object.GetComponent<Grid>().Modifying();
                                building_object.transform.position = selected_object.transform.parent.position;

                                gridSetting.GridReset();
                                Building_Grid_Check();

                            }
                        }
                    }
                }
            }           
                build_buttons.transform.position = Farming_Camera.WorldToScreenPoint(selected_object.transform.position + selected_object.GetComponent<BoxCollider>().center) + button_offset;

        }
        else if(mode == FARMING_MODE.PLANTING)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                //Debug.Log("down");
                Ray ray = Farming_Camera.ScreenPointToRay(Input.mousePosition);
                Debug.Log("Shoot");
                int layermask = 1 << LayerMask.NameToLayer("Dirt");
                Physics.Raycast(ray, out hit, 10000f, layermask);
               // Physics.Raycast(ray, out hit);
                //Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 2);
                Debug.DrawRay(ray.origin, ray.direction * 10000, Color.red, 5);
                Debug.Log(hit.collider);
                if (hit.collider != null)
                {            
                    objectcheck = hit.collider.gameObject;
                   
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                if (EventSystem.current.IsPointerOverGameObject())
                    return;
                RaycastHit hit;
                //Debug.Log("down");
                Ray ray = Farming_Camera.ScreenPointToRay(Input.mousePosition);
                int layermask = 1 << LayerMask.NameToLayer("Dirt");
                Physics.Raycast(ray, out hit, 10000f, layermask);
                //Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 2);
                //Physics.Raycast(ray, out hit);
                Debug.DrawRay(ray.origin, ray.direction * 10000, Color.red, 5);

                if (hit.collider != null)
                {
                    if (objectcheck == hit.collider.gameObject)
                    {                       
                        selected_object = hit.collider.gameObject;
                        gridSetting.GridReset();
                        Planting_Grid_Set();
                       
                    }
                }
            }
            if (selected_object)
            {
                if (selected_object.GetComponent<Dirt_Row>().plant_type != ITEM_PLANT_TYPE.NULL)
                {
                    build_buttons.transform.position = Farming_Camera.WorldToScreenPoint(selected_object.transform.position + selected_object.GetComponent<BoxCollider>().center) + button_offset;
                    build_buttons.SetActive(true);
                }
            }
        }
    }
    public void SetButtonColor(Image buttonimage)
    {
        if(Ground_Button == buttonimage)
        {
            Ground_Button.color=selected_Color;
            Crops_Button.color = unselected_Color;
            Building_Button.color = unselected_Color;
            Tree_Button.color = unselected_Color;
        }
        if (Crops_Button == buttonimage)
        {
            Ground_Button.color = unselected_Color;
            Crops_Button.color = selected_Color;
            Building_Button.color = unselected_Color;
            Tree_Button.color = unselected_Color;
        }
        if (Building_Button == buttonimage)
        {
            Ground_Button.color = unselected_Color;
            Crops_Button.color = unselected_Color;
            Building_Button.color = selected_Color;
            Tree_Button.color = unselected_Color;
        }
        if (Tree_Button == buttonimage)
        {
            Ground_Button.color = unselected_Color;
            Crops_Button.color = unselected_Color;
            Building_Button.color = unselected_Color;
            Tree_Button.color = selected_Color;
        }
    }
    public void Set_FarmingMode_Planting()
    {
        mode = FARMING_MODE.PLANTING;
        if (building_object != null&&building_object.transform.parent == null)
            Destroy(building_object);
        gridSetting.GridReset();
        building_object = null;
        selected_object = null;
    }
    public void Set_FarmingMode_Default()
    {
        mode = FARMING_MODE.DEFAULT;
        if (building_object!=null&&building_object.transform.parent == null)
            Destroy(building_object);
        gridSetting.GridReset();
        building_object = null;
        selected_object = null;
    }
    private void OnEnable()
    {
        if (selected_object)
        {
            if(selected_object.GetComponent<CollectableObject>())
                 selected_object.GetComponent<CollectableObject>().UnSelected();
            if (selected_object.GetComponent<Grid>())
                selected_object.GetComponent<Grid>().UnSelected();
            Collider[] c = Physics.OverlapBox(selected_object.GetComponent<BoxCollider>().center + selected_object.transform.position, selected_object.GetComponent<BoxCollider>().size / 2);
            foreach (Collider tmp in c)
            {

                if (tmp.GetComponent<Grid>())
                {
                    tmp.GetComponent<Grid>().UnSelected();

                }
            }
            selected_object = null;
        }
    }
    private void OnDisable()
    {

        if (selected_object)
        {
            Collider[] c = Physics.OverlapBox(selected_object.GetComponent<BoxCollider>().center + selected_object.transform.position, selected_object.GetComponent<BoxCollider>().size / 2);
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
        selected_object = null;

    }
    public void FarmBuildSetting(BUILD_OBJECT build_object)
    {
        if (selected_object)
        {
            if(selected_object.tag == "Grid")
            {
                if (building_object)
                {
                    Destroy(building_object);
                }
               Debug.Log(selected_object.transform.parent.position);
                building_object = Instantiate(Build_Prefabs[(int)build_object], selected_object.transform.parent.position, Quaternion.identity);
                //newGameobject.transform.SetParent(Selected_Object.transform.parent);
                mode = FARMING_MODE.BUILDING;
                Building_Grid_Check();
            }
        }
    }
    public void LoadBuilding(Grid_Save grid_Save)
    {
        Transform newobject = gridSetting.mainArray[grid_Save.grid_x].subArray[grid_Save.grid_z].transform;
        GameObject load_object = Instantiate(Build_Prefabs[(int)grid_Save.build_object], newobject.transform.position, Quaternion.identity);
        load_object.transform.SetParent(newobject.transform);
        if(grid_Save.build_object == BUILD_OBJECT.DIRT_ROW)
        {
            Dirt_Row dirt_Row = load_object.GetComponent<Dirt_Row>();
            if(grid_Save.plant_type!=ITEM_PLANT_TYPE.NULL)
            dirt_Row.Plant_Crop(grid_Save.plant_type);
            dirt_Row.plant_type = grid_Save.plant_type;
            if(dirt_Row.Get_Planted_Crop()!=null)
            dirt_Row.Get_Planted_Crop().GetComponent<Crops>().passed_day = grid_Save.passed_day;
        }
        Building_Object tmp_build = load_object.GetComponent<Building_Object>();

        tmp_build.grid_x = grid_Save.grid_x;
        tmp_build.grid_z = grid_Save.grid_z;

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
    public void Planting_Crop_On_DirtRow(UI_Item ui_Item)
    {
        if(mode == FARMING_MODE.PLANTING)
        {
            Dirt_Row tmp_dirt_row = selected_object.GetComponent<Dirt_Row>();
            if (tmp_dirt_row.plant_type == ITEM_PLANT_TYPE.NULL)
            {   
                tmp_dirt_row.Plant_Crop(ui_Item.item_plant_type);
                tmp_dirt_row.plant_type = ui_Item.item_plant_type;
            }
        }
    }
    public void Planting_Crop_On_DirtRow(ITEM_PLANT_TYPE type)
    {
        if (mode == FARMING_MODE.PLANTING)
        {
            Dirt_Row tmp_dirt_row = selected_object.GetComponent<Dirt_Row>();
            if (tmp_dirt_row.plant_type == ITEM_PLANT_TYPE.NULL)
            {
                tmp_dirt_row.Plant_Crop(type);
                tmp_dirt_row.plant_type = type;
            }
        }
    }
    public bool Building_Grid_Check()
    {
        build_buttons.transform.position = Farming_Camera.WorldToScreenPoint(building_object.transform.position + building_object.GetComponent<BoxCollider>().center) + button_offset;
        build_buttons.SetActive(true);

        bool value = true;
        Building_Object tmp_build = building_object.GetComponent<Building_Object>();
 
        tmp_build.grid_x = selected_object.GetComponent<Grid>().grid_x;
        tmp_build.grid_z = selected_object.GetComponent<Grid>().grid_z;
       
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
                {
                    if(mode == FARMING_MODE.BUILDING)
                      gridSetting.mainArray[tmp_build.grid_x + x].subArray[tmp_build.grid_z + z].GetComponentInChildren<Grid>().Able();
                    else if (mode == FARMING_MODE.MODIFY)
                        gridSetting.mainArray[tmp_build.grid_x + x].subArray[tmp_build.grid_z + z].GetComponentInChildren<Grid>().Modifying();
                }
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
        build_buttons.transform.position = Farming_Camera.WorldToScreenPoint(selected_object.transform.position + selected_object.GetComponent<BoxCollider>().center) + button_offset;
        build_buttons.SetActive(true);
        bool value = true;
        Building_Object tmp_build = selected_object.GetComponent<Building_Object>();

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
                gridSetting.mainArray[tmp_build.grid_x + x].subArray[tmp_build.grid_z + z].GetComponentInChildren<Grid>().buildable = true;
                if (gridSetting.mainArray[tmp_build.grid_x + x].subArray[tmp_build.grid_z + z].GetComponentInChildren<Grid>().buildable)
                    gridSetting.mainArray[tmp_build.grid_x + x].subArray[tmp_build.grid_z + z].GetComponentInChildren<Grid>().Modifying();
                else
                {
                    gridSetting.mainArray[tmp_build.grid_x + x].subArray[tmp_build.grid_z + z].GetComponentInChildren<Grid>().Disable();
                    value = false;
                }

            }
        }
        return value;
    }
    public void Planting_Grid_Set()
    {
        Building_Object tmp_build = selected_object.GetComponent<Building_Object>();
        for (int x = 0; x < tmp_build.size_x; x++)
        {
            for (int z = 0; z < tmp_build.size_z; z++)
            {
              if (!gridSetting.mainArray[tmp_build.grid_x + x].subArray[tmp_build.grid_z + z].GetComponentInChildren<Grid>().buildable)
                {
                        gridSetting.mainArray[tmp_build.grid_x + x].subArray[tmp_build.grid_z + z].GetComponentInChildren<Grid>().Modifying();
                }
            }
        }
    }
    public void Building_Grid_Set()
    {
        //bool value = true;
        Building_Object tmp_build = building_object.GetComponent<Building_Object>();

        tmp_build.grid_x = selected_object.GetComponent<Grid>().grid_x;
        tmp_build.grid_z = selected_object.GetComponent<Grid>().grid_z;

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
                building_object.transform.SetParent(selected_object.transform.parent);
                build_buttons.SetActive(false);
                building_object = null;
                selected_object = null;
                mode = FARMING_MODE.DEFAULT;
            }
            else return;
        }
        if(mode == FARMING_MODE.MODIFY)
        {
            if (Building_Grid_Check())
            {
                Building_Grid_Set();
                building_object.transform.SetParent(selected_object.transform.parent);
                build_buttons.SetActive(false);
                building_object = null;
                selected_object = null;
                mode = FARMING_MODE.DEFAULT;
            }
            else return;
        }
        if(mode == FARMING_MODE.PLANTING)
        {
            build_buttons.SetActive(false);
            building_object = null;
            selected_object = null;
        }
        gridSetting.GridReset();
    }

    public void Build_Cancel()
    {
        if (mode == FARMING_MODE.BUILDING)
        {
            Destroy(building_object);
            build_buttons.SetActive(false);
            building_object = null;
            selected_object = null;
            mode = FARMING_MODE.DEFAULT;
        }
        if (mode == FARMING_MODE.MODIFY)
        {
            Destroy(building_object);
            build_buttons.SetActive(false);
            building_object = null;
            selected_object = null;
            mode = FARMING_MODE.DEFAULT;
        }
        if (mode == FARMING_MODE.PLANTING)
        {

             Dirt_Row tmp_dirt_row = selected_object.GetComponent<Dirt_Row>();
             tmp_dirt_row.plant_type = ITEM_PLANT_TYPE.NULL;
             tmp_dirt_row.DestroyCrop();
             build_buttons.SetActive(false);
            building_object = null;
            selected_object = null;

        }
        gridSetting.GridReset();
        build_buttons.SetActive(false);

    }
}
