using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Trees_Setting : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnEnable()
    {
        UI_Build[] uI_trees = GetComponentsInChildren<UI_Build>();
        foreach (UI_Build uI_tree in uI_trees)
        {
            uI_tree.SetNum();
        }

    }
}
