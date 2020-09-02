using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterData :MonoBehaviour
{
    public SaveData inGameData;
    public void Save()
    {
        //가방 저장
        UI_Inventory uI_Inventory = FindObjectOfType<GameController>().ui_inventory;
        //foreach(UI_ITEM_PLANT_INFO item in uI_Inventory.inventory_Items_Plants)
        //{
        //    inGameData.items[(int)item.itemType] = item;
        //}
        inGameData.items = uI_Inventory.inventory_Items_Plants; 
        //퀘스트 저장
        Quest[] quests = FindObjectOfType<QuestController>().quests;
        inGameData.quests.Clear();
        foreach(Quest q in quests)
        {
            //inGameData.quests[q.Quest_Num].Quest_num = q.Quest_Num;
            //inGameData.quests[q.Quest_Num].quest_state = q.quest_state;
            Quest_Save quest_Save;
            quest_Save.Quest_num = q.Quest_Num;
            quest_Save.quest_state = q.quest_state;
            inGameData.quests.Add(quest_Save);
        }
        //inGameData.mainArray = FindObjectOfType<GridSetting>().mainArray;

        //그리드 저장
        if (FindObjectOfType<GridSetting>())
        {
            Building_Object[] building_Objects = FindObjectsOfType<Building_Object>();
            foreach(Building_Object b in building_Objects)
            {

                Grid_Save grid_Save=new Grid_Save();
                grid_Save.build_object = b.build_object;
                grid_Save.grid_x = b.grid_x;
                grid_Save.grid_z = b.grid_z;
                if(b.build_object == BUILD_OBJECT.DIRT_ROW)
                {
                    grid_Save.passed_day = b.GetComponent<Dirt_Row>().Get_Planted_Crop().GetComponent<Crops>().passed_day;
                    grid_Save.plant_type = b.GetComponent<Dirt_Row>().plant_type;
                }
                inGameData.grid_Saves.Add(grid_Save);
            }
        }

    }
    public void Write()
    {
        SaveSystem.SavePlayer(inGameData.filename, inGameData);

    }
    public void Load()
    {
        //가방 불러오기
        UI_Inventory uI_Inventory = FindObjectOfType<GameController>().ui_inventory;
        //uI_Inventory.inventory_Items_Plants = inGameData.items;
        foreach (UI_ITEM_PLANT_INFO item in inGameData.items)
        {
            uI_Inventory.inventory_Items_Plants[(int)item.itemType] = item;
        }
        //퀘스트 불러오기
        Quest[] quests= FindObjectOfType<QuestController>().quests;
        foreach (Quest_Save q in inGameData.quests)
        {
            quests[q.Quest_num].quest_state = q.quest_state;
        }

    }

}
