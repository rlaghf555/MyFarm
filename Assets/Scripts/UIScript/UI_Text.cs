using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Text : MonoBehaviour
{
    private void OnDisable()
    {
        GetComponent<Text>().text = "";
    }
}
