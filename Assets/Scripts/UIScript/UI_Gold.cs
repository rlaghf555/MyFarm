using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Gold : MonoBehaviour
{
    public Text goldtext;
    // Start is called before the first frame update
    private void OnEnable()
    {
        Debug.Log("enable gold");
        SetGoldText();
    }// Update is called once per frame
    public void SetGoldText()
    {
        int gold =FindObjectOfType<CharacterData>().inGameData.gold;
        goldtext.text = ("Gold - " + gold.ToString() + "G");
    }
   
}
