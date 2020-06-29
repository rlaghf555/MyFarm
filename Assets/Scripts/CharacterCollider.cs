using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollider : MonoBehaviour
{
    [HideInInspector]
    public GameObject colGameObject;
    public GameObject lines;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        colGameObject = other.gameObject;
        if(colGameObject.tag == "Portal")
        {
            OpenScript();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        colGameObject = null;
    }
    public void OpenScript()
    {
        lines.SetActive(true);
        colGameObject.GetComponent<Line>().SetScripts(); ;
    }
}
