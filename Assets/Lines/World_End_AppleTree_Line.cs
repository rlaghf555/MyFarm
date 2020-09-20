using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World_End_AppleTree_Line : Line
{

    public GameObject DeletePanel;

    // Start is called before the first frame update
    void Start()
    {
        getline = FindObjectOfType<GameController>().ui_script;
    }
   
    override public void EndFunction()
    {
        DeletePanel.SetActive(true);
    }



}
