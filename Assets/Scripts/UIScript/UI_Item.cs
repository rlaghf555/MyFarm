using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Item : MonoBehaviour
{
    public string Kor_Name;
    public string Eng_Name;
    [TextArea]
    public string Kor_Text;
    [TextArea]
    public string Eng_Text;
    private TextMesh Item_Name;
    private TextMesh Item_Text;
    public TextMesh t_num;
    public int i_num;

    public void SetItemInfo()
    {
        Item_Text = GameObject.Find("Item Text").GetComponent<TextMesh>();
        Item_Name = GameObject.Find("Item Name").GetComponent<TextMesh>();
        Item_Name.text = Kor_Name;
        Item_Text.text = Kor_Text;
    }
    public void UseItem()
    {
        i_num--;
        SetNumText();
    }
    public void SetNumText()
    {
        t_num.text = "X" + i_num.ToString();
    }
}
