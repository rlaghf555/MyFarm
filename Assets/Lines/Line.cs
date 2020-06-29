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
    public virtual void SetScripts()
    {
        getline.SetScripts(lines);
    }
    

}
