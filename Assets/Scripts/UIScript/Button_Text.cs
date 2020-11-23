using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_Text : MonoBehaviour
{
    public Text text;
    public string kortext;
    public string engtext;
    private void OnEnable()
    {
        if (FindObjectOfType<GameSetting>().gameSettingData.iskor)
        {
            text.text = kortext;
        }
        else
        {
            text.text = engtext;
        }
    }
}
