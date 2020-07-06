using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GridSetting : MonoBehaviour
{
    public Transform[] treePrefabs;
    public int x_size;
    public int z_size;
    public int gap;
    public Transform position;
    // Start is called before the first frame update
    void Start()
    {
    }
    private void Awake()
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
                for(int i = 0; i < collider.Length; i++)
                {
                    if (collider[i].tag != "Ground"&&collider[i].tag!="Hill")
                    {
                        Debug.Log(collider[i].tag);
                        trig = false;
                    }
                }
                if(trig)
                Instantiate(treePrefabs[0], gizmosPos, Quaternion.identity, transform);

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDrawGizmos()
    {
        for(int x = 0; x < x_size; x++)
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
}
