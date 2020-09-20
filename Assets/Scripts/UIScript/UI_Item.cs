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
    [SerializeField]
    private TextMesh t_num;
    public int i_num;
    public int cost;
    public ITEM_PLANT_TYPE item_plant_type;
    private void Awake()
    {
    }
    public void SetItemInfo()
    {
        Item_Text = GameObject.Find("Item Text").GetComponent<TextMesh>();
        Item_Name = GameObject.Find("Item Name").GetComponent<TextMesh>();
        Item_Text.text = Kor_Text;
        Item_Name.text = Kor_Name;
        if (GameObject.Find("Trade"))
        {
            Debug.Log("setitem");
            GameObject.Find("Trade").GetComponent<UI_Trade>().setItem(this);
        }
    }
    public void UseItem()
    {
        i_num--;
        SetNumText();
    }
    public void SetNumText()
    {
        t_num.fontSize = 0;
        t_num.text = "X" + i_num.ToString();
    }
    public void SetPlantInfo()
    {

        GameObject.Find("Build Name").GetComponent<Text>().text = Kor_Name;
        GameObject.Find("Build Text").GetComponent<Text>().text = Kor_Text;

    }
    public void SetNum()
    {
        
        //Debug.Log(FindObjectOfType<UI_Inventory>().inventory_Items_Plants[1].num);
        //i_num = Resources.FindObjectsOfTypeAll<UI_Inventory>()[0].inventory_Items_Plants[(int)item_plant_type].num;
        foreach(UI_ITEM_PLANT_INFO myinventory in FindObjectOfType<CharacterData>().inGameData.items)
        {
            if(myinventory.itemType == item_plant_type)
            {
                i_num = myinventory.num;
                break;
            }
        }
        SetNumText();
    }
    public void Build_On_Click()
    {

    }
}
