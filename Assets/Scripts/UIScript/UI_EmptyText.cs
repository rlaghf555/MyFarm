using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_EmptyText : MonoBehaviour
{
    public GameObject text;
    // Start is called before the first frame update



    private void FixedUpdate()
    {
        SetText();
    }
    public void SetText()
    {
        if (transform.childCount > 0)
        {
            text.SetActive(false);
        }
        else
            text.SetActive(true);
    }
   
}
