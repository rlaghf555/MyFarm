using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_EmptyText : MonoBehaviour
{
    public GameObject content;
    private MeshRenderer meshRenderer;
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (content.transform.childCount == 0)
        {
            meshRenderer.enabled = true;
        }
        else
            meshRenderer.enabled = false;
    }
}
