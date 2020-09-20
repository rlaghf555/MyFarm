using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollider : MonoBehaviour
{
    //[HideInInspector]
    public GameObject colGameObject;
    public GameObject lines;
    public GameObject openScriptButton;
    public GameObject TradeButton;
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
        if (other.tag == "Grid")
            return;
        colGameObject = other.gameObject;
        Debug.Log(colGameObject);
        //if(colGameObject.tag == "Portal")
        //{
        //    OpenScript();
        //}
        if(colGameObject.tag == "NPC"||colGameObject.tag == "Collectable"||colGameObject.tag=="Sign"||colGameObject.tag=="Building")
        {
            openScriptButton.SetActive(true);
        }
        if(colGameObject.tag == "NPC")
        {
            TradeButton.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Grid")
            return;
        if (colGameObject == null)
            return;
        if (colGameObject.tag == "NPC" || colGameObject.tag == "Collectable" || colGameObject.tag == "Sign" || colGameObject.tag == "Building")
        {            
            openScriptButton.SetActive(false);
            TradeButton.SetActive(false);

        }
        colGameObject = null;
    }
    public void OpenScript()
    {
        lines.SetActive(true);
        Debug.Log(colGameObject+"openscript");

        colGameObject.GetComponent<Line>().SetScripts();
        if(colGameObject.tag == "NPC")
        {
            colGameObject.GetComponent<Animator>().SetTrigger("Talk_Start");
            colGameObject.GetComponent<LookCharacter>().enabled = true;
        }
    }
    public void EndScript()
    {
        if (colGameObject.tag == "NPC")
        {
            colGameObject.GetComponent<Animator>().SetTrigger("Talk_End");
            colGameObject.GetComponent<LookCharacter>().enabled = false;
        }
    }
}
