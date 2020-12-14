using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Crops_Setting : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnEnable()
    {
        UI_Item[] uI_Items = GetComponentsInChildren<UI_Item>();
        foreach(UI_Item uI_Item in uI_Items)
        {
            uI_Item.SetNum();
        }

    }
}
