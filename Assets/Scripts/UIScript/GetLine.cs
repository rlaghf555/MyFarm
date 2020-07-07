﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GetLine : MonoBehaviour
{
    public GameObject parent;
    public List<string> lines;
    private int linenum;
    private int lineOn;
    public Text text;
    public CharacterCollider characterCollider;
    // Start is called before the first frame update



    public void SetScripts(List<string> value)
    {
        //FindObjectOfType<PlayerInput>().enabled = false;
        FindObjectOfType<CharacterMoveByJoystick>().enabled = false;
        lines = value.ToList<string>();
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
            //FindObjectOfType<PlayerInput>().enabled = true;
            FindObjectOfType<CharacterMoveByJoystick>().enabled = true;
            characterCollider.EndScript();
            lines.Clear();
            return;
        }

        text.text = lines[lineOn];
        lineOn++;

    }
}
