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
    public void SetCollectableObject()
    {
        for (int x = 0; x < x_size; x++)
        {
            for (int z = 0; z < z_size; z++)
            {

                // if (Random.Range(0, 2) == 0)
                //   continue;
                Vector3 gizmosPos = transform.position;
                gizmosPos.x += x * gap;
                gizmosPos.z -= z * gap;
                Collider[] collider = Physics.OverlapSphere(gizmosPos, 2.5f);
                bool trig = true;
                for (int i = 0; i < collider.Length; i++)
                {
                    if (collider[i].tag != "Ground" && collider[i].tag != "Hill")
                    {
                        Debug.Log(collider[i].tag);
                        trig = false;
                    }
                }
                Quaternion q = Quaternion.identity;
                q.eulerAngles = new Vector3(90, 0, 0);
                Vector3 boxpos = gizmosPos;
                boxpos.y = -0.3f;
                mainArray[x].subArray[z] = Instantiate(gridBox, boxpos, q,grid.transform);
                if (trig)
                {
                    Instantiate(treePrefabs[0], gizmosPos, Quaternion.identity).parent = mainArray[x].subArray[z].transform;
                }

            }
        }
    }
    public void DrawGrid()
    {
        Vector3 tmp = new Vector3(0, 0, 0);
        Gizmos.color = Color.red;
        for (int x = 0; x < x_size; x++)
        {
            for (int z = 0; z < z_size; z++)
            {

                // if (Random.Range(0, 2) == 0)
                //   continue;
                Vector3 gizmosPos = transform.position;
                gizmosPos.x += x * gap;
                gizmosPos.z -= z * gap;
                Gizmos.DrawLine(gizmosPos, tmp);
                tmp = gizmosPos;

            }
        }
    }
}
