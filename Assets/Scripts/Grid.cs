using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public int grid_x;
    public int grid_z;
    public bool buildable = true;
    public void Disable()
    {
        //GetComponent<SpriteRenderer>().color = Color.red;
        GetComponent<Outline>().OutlineColor = Color.red;
    }
    public void Able()
    {
        //GetComponent<SpriteRenderer>().color = Color.green;
        GetComponent<Outline>().OutlineColor = Color.green;
    }
    public void Modifying()
    {
        GetComponent<Outline>().OutlineColor = Color.magenta;

    }
    public void UnSelected()
    {
        //GetComponent<SpriteRenderer>().color = Color.white;
        GetComponent<Outline>().OutlineColor = Color.white;
    }
    public void Invisible()
    {
        GetComponent<Outline>().OutlineColor = new Color(0,0,0,0);
    }
}
