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
    public override void korLine()
    {
        lines.Add("땅끝에 온걸 환영해.");
        lines.Add("이 너머에 뭐가 있는지는 나도 몰라");
        lines.Add("그래도 떠날꺼니?");
    }
    override public void EndFunction()
    {
        DeletePanel.SetActive(true);
    }



}
