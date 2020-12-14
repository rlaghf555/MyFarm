using UnityEngine;
using System.Collections;

public class UI_Trade : MonoBehaviour
{
    private UI_Item trading_item;
    private UI_Inventory my_inventory;
    private UI_NPC_Inventory npc_inventory;
    private bool is_sell = true;
    // Use this for initialization
 
    public void setItem(UI_Item r_value)
    {
        trading_item = r_value;
        Debug.Log("setitem:" + trading_item.Kor_Name);
    }
    public void Trade()
    {
        my_inventory = GetComponent<UI_Inventory>();
        npc_inventory = GetComponent<UI_NPC_Inventory>();
        // if (!trading_item)
        //     return;
        CharacterData characterData = FindObjectOfType<CharacterData>();
        if (is_sell) // 판매
        {
            Debug.Log("판매 - "+ trading_item.item_plant_type);
            foreach(UI_ITEM_PLANT_INFO mu in my_inventory.inventory_Items_Plants)
            {

                if (mu.itemType == trading_item.item_plant_type)
                {
                    Debug.Log(mu.itemType+":"+mu.num);
                    //Debug.Log("1:"+ mu.num);
                    if (mu.num > 0)
                    {

                        mu.num--;
                        trading_item.i_num--;
                        trading_item.SetNumText();
                        characterData.inGameData.gold += trading_item.cost;
                        Debug.Log(characterData.inGameData.gold);

                        foreach (UI_ITEM_PLANT_INFO nu in npc_inventory.inventory_Items_Plants)
                        {
                            if(nu.itemType == trading_item.item_plant_type|| nu.itemType ==ITEM_PLANT_TYPE.NULL)
                            {
                                nu.itemType = trading_item.item_plant_type;
                                nu.num++;
                                Debug.Log(trading_item.Kor_Name + ":" + trading_item.i_num);

                                break;
                            }
                        }
                        if (mu.num == 0)
                        {
                            mu.itemType = ITEM_PLANT_TYPE.NULL;
                            my_inventory.SetInventory();
                        }
                        break;
                    }
                }
               // Debug.Log(trading_item.Kor_Name + ":" + trading_item.i_num);
            }
        }
        else // 구입
        {
            Debug.Log("구입");

            foreach (UI_ITEM_PLANT_INFO nu in npc_inventory.inventory_Items_Plants)
            {
                if (nu.itemType == trading_item.item_plant_type)
                {
                    if (nu.num > 0)
                    {
                        if (characterData.inGameData.gold >= trading_item.cost)
                        {
                            nu.num--;
                            trading_item.i_num--;
                            trading_item.SetNumText();
                            characterData.inGameData.gold -= trading_item.cost;
                            foreach (UI_ITEM_PLANT_INFO mu in my_inventory.inventory_Items_Plants)
                            {
                                if (mu.itemType == trading_item.item_plant_type || mu.itemType == ITEM_PLANT_TYPE.NULL)
                                {
                                    mu.itemType = trading_item.item_plant_type;
                                    mu.num++;
                                    Debug.Log(trading_item.Kor_Name + ":" + trading_item.i_num);
                                    break;
                                }
                            }
                            if (nu.num == 0)
                            {
                                nu.itemType = ITEM_PLANT_TYPE.NULL;
                                npc_inventory.SetInventory();
                            }
                            Debug.Log(trading_item.Kor_Name + ":" + trading_item.i_num);
                        }
                        break;
                    }
                }
            }
           // Debug.Log(trading_item.Kor_Name + ":" + trading_item.i_num);

        }
        FindObjectOfType<UI_Gold>().SetGoldText();

    }
    public void Is_Sell(bool r_value)
    {
        is_sell = r_value;
    }
}
