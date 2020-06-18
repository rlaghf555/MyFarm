using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetLine : MonoBehaviour
{
    public GameObject parent;
    public List<string> lines;
    private int linenum;
    private int lineOn;
    public Text text;

    // Start is called before the first frame update

    void Start()
    {
    }
    
    public void SetScripts(List<string> value)
    {
        FindObjectOfType<PlayerInput>().enabled = false;
        lines = value;
        linenum = value.Count-1;
        lineOn = 0;
        text.text = value[lineOn];
        lineOn++;
    }
    public void NextLine()
    {
        if(lineOn> linenum)
        {
            parent.SetActive(false);
            FindObjectOfType<PlayerInput>().enabled = true;
            return;
        }

        text.text = lines[lineOn];
        lineOn++;

    }
}
