﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollider : MonoBehaviour
{
    //[HideInInspector]
    public GameObject colGameObject;
    public GameObject lines;
    public GameObject openScriptButton;
    public GameObject TradeButton;
    public QuestController questController;
    // Start is called before the first frame update
 
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
        if(colGameObject.tag == "NPC"||colGameObject.tag == "Collectable"||colGameObject.tag=="Sign"||colGameObject.tag=="Building" || colGameObject.tag == "Junk")
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
        if (colGameObject.tag == "NPC" || colGameObject.tag == "Collectable" || colGameObject.tag == "Sign" || colGameObject.tag == "Building" || colGameObject.tag == "Junk")
        {            
            openScriptButton.SetActive(false);
            TradeButton.SetActive(false);

        }
        colGameObject = null;
    }
    public void OpenScript()
    {
        Debug.Log(colGameObject+"openscript");

        if(colGameObject.tag == "NPC")
        {
            int character_num = colGameObject.GetComponent<Character>().Character_Num;
            Line questline = questController.FindQuestLine(character_num);
            if (questline == null)
                return;
            Debug.Log("line_num = "+questline.Line_Num);
            Debug.Log(questline.korLines[0]);

            if (questline != null)
            {
                questline.SetScripts();
            }
            
            colGameObject.GetComponent<Animator>().SetTrigger("Talk_Start");
            //colGameObject.GetComponent<LookCharacter>().enabled = true;
        }
        if (colGameObject.GetComponent<Line>())
        {
            colGameObject.GetComponent<Line>().SetScripts();
        }
        lines.SetActive(true);

    }
    public void EndScript()
    {
        if (colGameObject.tag == "NPC")
        {
            colGameObject.GetComponent<Animator>().SetTrigger("Talk_End");
            //colGameObject.GetComponent<LookCharacter>().enabled = false;
        }
    }
    public void RemoveJunk() { 
        if(colGameObject.tag == "Junk")
        {
            colGameObject.GetComponent<Junk>().Remove();
        }
    }
}
