using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum UI_ITEM_TYPE
{
    NULL,APPLE,APRICOT,ASPARAGUS,BANANA,BEAN,BEETROOT,BROCCOLI,
    CABBAGE,CARROT,CHERRY,CHILLI,CORN,CUCUMBER,EGGPLANT,LEMON,
    LETTUCE,ONION,ORANGE,PEACH,PEAR,PEPPER,PLUM,POTATO,PUMPKIN,
    PUMPKIN_ITALIAN,PUMPKIN_WHITE,SQUASH_BUTTERNUT,
    SQUASH_DELICATA,STRAWBERRY,TOMATO,WATERMELON
}
;
[System.Serializable]
public class UI_ITEM_INFO
{
    public UI_ITEM_TYPE itemType = UI_ITEM_TYPE.NULL;
    public int num;
}
public class UI_Inventory : MonoBehaviour
{
    public UI_ITEM_INFO[] inventory_Items_Plants = new UI_ITEM_INFO[(int)UI_ITEM_TYPE.WATERMELON];
    public GameObject Content;
    public GameObject[] item_plants_prefabs;
    // Start is called before the first frame update
    void Start()
    {
        //items = new UI_ITEM_INFO[50];
        //setinventory
    }
    private void Awake()
    {
        SetInventory();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetInventory()
    {
        for(int i = 0; i < inventory_Items_Plants.Length; i++)
        {
            inventory_Items_Plants[i].itemType = (UI_ITEM_TYPE)i;
            inventory_Items_Plants[i].num = i;
            Vector3 pos = new Vector3(10 + (i % 2) * 25, -10 - (i / 2) * 28, 0);

            GameObject newObject = Instantiate(item_plants_prefabs[(int)inventory_Items_Plants[i].itemType],Content.transform);

            newObject.GetComponent<RectTransform>().anchoredPosition = pos;
            if (i == 0)
            {
                newObject.GetComponent<UI_Item>().SetItemInfo();
            }
            newObject.GetComponent<UI_Item>().i_num = inventory_Items_Plants[i].num;
            newObject.GetComponent<UI_Item>().SetNumText();
        }
    }
    public void ReSetInventory()
    {

    }
}
