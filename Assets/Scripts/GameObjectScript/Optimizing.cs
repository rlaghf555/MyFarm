using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Optimizing : MonoBehaviour
{
    public Transform o_transform;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            for(int i = 0; i < o_transform.childCount; i++)
            {
                o_transform.GetChild(i).gameObject.SetActive(true);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            for (int i = 0; i < o_transform.childCount; i++)
            {
                o_transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}
