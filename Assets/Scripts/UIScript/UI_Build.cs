using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Build : MonoBehaviour
{
    public BUILD_OBJECT build_object;
    public ITEM_PLANT_TYPE item_plant_type;
    public string Kor_Name;
    public string Eng_Name;
    [TextArea,SerializeField]
    private string Kor_Text;
    [TextArea, SerializeField]
    private string Eng_Text;
    [SerializeField]
    private TextMesh t_num;
    public int i_num;
    // Start is called before the first frame update
    public Farming_Control farming_Control;
    private void Awake()
    {
        t_num.fontSize = 0;

        farming_Control = GameObject.Find("Farming_Camera").GetComponent<Farming_Control>();
    }
    private void OnEnable()
    {
        t_num.fontSize = 0;

    }
    public void onclick()
    {
        farming_Control.FarmBuildSetting(build_object);
    }
    public void SetBuildInfo()
    {
        if (FindObjectOfType<GameSetting>().gameSettingData.iskor)
        {
            GameObject.Find("Build Name").GetComponent<Text>().text = Kor_Name;
            GameObject.Find("Build Text").GetComponent<Text>().text = Kor_Text;
        }
        else
        {
            GameObject.Find("Build Name").GetComponent<Text>().text = Eng_Name;
            GameObject.Find("Build Text").GetComponent<Text>().text = Eng_Text;
        }
    }
    public void SetNumText()
    {
        t_num.fontSize = 0;
        t_num.text = "X" + i_num.ToString();

    }
    public void SetNum()
    {

        //Debug.Log(FindObjectOfType<UI_Inventory>().inventory_Items_Plants[1].num);
        //i_num = Resources.FindObjectsOfTypeAll<UI_Inventory>()[0].inventory_Items_Plants[(int)item_plant_type].num;
        foreach (UI_ITEM_PLANT_INFO myinventory in FindObjectOfType<CharacterData>().inGameData.items)
        {
            if (myinventory.itemType == item_plant_type)
            {
                i_num = myinventory.num;
                break;
            }
        }
        SetNumText();
    }

}
