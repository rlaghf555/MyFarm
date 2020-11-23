using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    public int Line_Num;
    public List<string> lines;
    public string[] korLines;
    public string[] engLines;
    protected GetLine getline;

    // Start is called before the first frame update
    void Start()
    {
        getline = FindObjectOfType<GameController>().ui_script;
    }
    public virtual void korLine()
    {
        foreach(string s in korLines)
        {
            lines.Add(s);
        }
    }
    public virtual void engLine()
    {
        foreach (string s in engLines)
        {
            lines.Add(s);
        }
    }
    public virtual void SetScripts()
    {
        lines.Clear();
        if (FindObjectOfType<GameSetting>().gameSettingData.iskor)
        {
            korLine();
        }
        else
        {
            engLine();
        }
        getline.SetScripts(lines, this);
    }
    public virtual void EndFunction()
    {
    }



}
