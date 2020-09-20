using UnityEngine;
using System.Collections;

public class UI_NPC_Inventory : UI_Inventory
{

    // Use this for initialization 
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    public override void SetInventory()
    {
        GameObject npc = FindObjectOfType<CharacterCollider>().colGameObject;
        int n = Plant_Content.transform.childCount;
        for (int i = 0; i < n; i++)
        {
            Destroy(Plant_Content.transform.GetChild(i).gameObject);
        }
        if (npc)
        {
            //foreach (UI_ITEM_PLANT_INFO item in inventory_Items_Plants)
            //{
            //    item.itemType = ITEM_PLANT_TYPE.NULL;
            //    item.num = 0;
            //}
            inventory_Items_Plants = npc.GetComponent<UI_NPC_Inventory>().inventory_Items_Plants;

           // for (int i = 0; i < inventory_Items_Plants.Length; i++)
           // {
           //     inventory_Items_Plants[i].itemType = characterData.inGameData.items[i].itemType;
           //     inventory_Items_Plants[i].num = characterData.inGameData.items[i].num;
           // }
            for (int i = 0, j = 0; i < inventory_Items_Plants.Length; i++)
            {
                if (inventory_Items_Plants[i].itemType == ITEM_PLANT_TYPE.NULL)
                {
                    continue;
                }
                Vector3 pos = new Vector3(5 + (j % 2) * 25, -10 - (j / 2) * 28, 0);
                j++;
                Vector2 tmp = Plant_Content.GetComponent<RectTransform>().sizeDelta;
                tmp.y = -(-10 - (j / 2) * 28) + 28;
                Plant_Content.GetComponent<RectTransform>().sizeDelta = tmp;
                GameObject newObject = Instantiate(item_plants_prefabs[(int)inventory_Items_Plants[i].itemType], Plant_Content.transform);

                newObject.GetComponent<RectTransform>().anchoredPosition = pos;
                if (j == 0)
                {
                    newObject.GetComponent<UI_Item>().SetItemInfo();
                }
                newObject.GetComponent<UI_Item>().i_num = inventory_Items_Plants[i].num;
                newObject.GetComponent<UI_Item>().SetNumText();
            }
        }
        else
        {
            for (int i = 0, j = 0; i < inventory_Items_Plants.Length; i++)
            {
                j++;
                inventory_Items_Plants[i].itemType = (ITEM_PLANT_TYPE)i;
                if (inventory_Items_Plants[i].itemType == ITEM_PLANT_TYPE.NULL)
                {
                    continue;
                }
                inventory_Items_Plants[i].num = i;
                Vector3 pos = new Vector3(5 + (j % 2) * 25, 20 - (j / 2) * 28, 0);

                GameObject newObject = Instantiate(item_plants_prefabs[(int)inventory_Items_Plants[i].itemType], Plant_Content.transform);

                newObject.GetComponent<RectTransform>().anchoredPosition = pos;
                if (j == 0)
                {
                    newObject.GetComponent<UI_Item>().SetItemInfo();
                }
                newObject.GetComponent<UI_Item>().i_num = inventory_Items_Plants[i].num;
                newObject.GetComponent<UI_Item>().SetNumText();
            }
        }
    }
}
