using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[Serializable]
public class SubArray
{
    public GameObject[] subArray = new GameObject[14];
}
public class GridSetting : MonoBehaviour
{
    public Transform[] treePrefabs;
    const int x_size = 50;
    const int z_size = 14;
    public int gap;
    public Transform position;
    public SubArray[] mainArray = new SubArray[50];
    public GameObject gridBox;
    public GameObject grid;
    // Start is called before the first frame update
    void Start()
    {
    }
    private void Awake()
    {
        SetCollectableObject();
    }

    // Update is called once per frame
    void Update()
    {

    }
    /*
    private void OnDrawGizmos()
    {
        for (int x = 0; x < x_size; x++)
        {
            for (int z = 0; z < z_size; z++)
            {
                Vector3 gizmosPos = transform.position;
                gizmosPos.x += x * gap;
                gizmosPos.z -= z * gap;
                Gizmos.DrawSphere(gizmosPos, 0.1f);

            }
        }
    }
    */
    public void SetCollectableObject()
    {
        for (int x = 0; x < x_size; x++)
        {
            for (int z = 0; z < z_size; z++)
            {

                // if (Random.Range(0, 2) == 0)
                //   continue;
                Vector3 pos = transform.position;
                pos.x += x * gap;
                pos.z -= z * gap;
                Collider[] collider = Physics.OverlapSphere(pos, 2.5f);
                bool trig = true;
                for (int i = 0; i < collider.Length; i++)
                {
                    if (collider[i].tag != "Ground" && collider[i].tag != "Hill" && collider[i].tag !="Grid")
                    {
                        Debug.Log(collider[i].tag);
                        trig = false;
                    }
                }
                Quaternion q = Quaternion.identity;
               // q.eulerAngles = new Vector3(90, 0, 0);
                Vector3 boxpos = pos;
                boxpos.y = -0.3f;
                mainArray[x].subArray[z] = Instantiate(gridBox, boxpos, q, grid.transform);
                mainArray[x].subArray[z].GetComponentInChildren<Grid>().grid_x = x;
                mainArray[x].subArray[z].GetComponentInChildren<Grid>().grid_z = z;
                if (trig)
                {
                    //boxpos.y = -0.5f;
                    //
                    //Transform newObject = Instantiate(treePrefabs[0], boxpos, Quaternion.identity);
                    //newObject.parent = mainArray[x].subArray[z].transform;
                    //newObject.GetComponent<CollectableObject>().grid_x = x;
                    //newObject.GetComponent<CollectableObject>().grid_z = z;
                    //mainArray[x].subArray[z].GetComponentInChildren<Grid>().buildable = false;
                }

            }
        }
    }

    public void GridReset()
    {
        for (int x = 0; x < x_size; x++)
        {
            for (int z = 0; z < z_size; z++)
            {
                mainArray[x].subArray[z].GetComponentInChildren<Grid>().UnSelected();
            }
        }
    }
}
