using UnityEngine;
using System.Collections;

public class Junk_Line : Line
{
    private GameObject RemoveJunk;
    void Start()
    {
        getline = FindObjectOfType<GameController>().ui_script;
        RemoveJunk = FindObjectOfType<GameController>().RemoveJunkUI;
    }
    public override void EndFunction()
    {
        RemoveJunk.SetActive(true);
    }
}
