using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{

    public List<string> lines;
    protected GetLine getline;

    // Start is called before the first frame update
    void Start()
    {
        getline = FindObjectOfType<GameController>().ui_script;
    }
    public virtual void korLine()
    {

    }
    public virtual void engLine()
    {

    }
    public virtual void SetScripts()
    {
        lines.Clear();
        korLine();
        getline.SetScripts(lines, this);
    }
    public virtual void EndFunction()
    {
    }



}
