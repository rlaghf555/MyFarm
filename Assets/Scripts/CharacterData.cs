using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterData :MonoBehaviour
{
    public SaveData inGameData;
    public string BeforeScene=null;
    public void Save()
    {
        //가방 저장
        UI_Inventory uI_Inventory = FindObjectOfType<GameController>().ui_inventory;
        //foreach(UI_ITEM_PLANT_INFO item in uI_Inventory.inventory_Items_Plants)
        //{
        //    inGameData.items[(int)item.itemType] = item;
        //}
        for(int i = 0; i < inGameData.items.Length; i++)
        {
            inGameData.items[i].itemType = uI_Inventory.inventory_Items_Plants[i].itemType ;
            inGameData.items[i].num = uI_Inventory.inventory_Items_Plants[i].num ;

        }
        //퀘스트 저장
        Quest[] quests = FindObjectOfType<QuestController>().quests;
        inGameData.quests.Clear();
        foreach(Quest q in quests)
        {
            //inGameData.quests[q.Quest_Num].Quest_num = q.Quest_Num;
            //inGameData.quests[q.Quest_Num].quest_state = q.quest_state;
            Quest_Save quest_Save = new Quest_Save();
            quest_Save.Quest_num = q.Quest_Num;
            quest_Save.quest_state = q.quest_state;
            inGameData.quests.Add(quest_Save);
        }
        //inGameData.mainArray = FindObjectOfType<GridSetting>().mainArray;

        //그리드 저장
        if (FindObjectOfType<GridSetting>())
        {
            inGameData.grid_Saves.Clear();
            Building_Object[] building_Objects = FindObjectsOfType<Building_Object>();
            foreach(Building_Object b in building_Objects)
            {

                Grid_Save grid_Save=new Grid_Save();
                grid_Save.build_object = b.build_object;
                grid_Save.grid_x = b.grid_x;
                grid_Save.grid_z = b.grid_z;
                if(b.build_object == BUILD_OBJECT.DIRT_ROW)
                {
                    if (b.GetComponent<Dirt_Row>().plant_type != ITEM_PLANT_TYPE.NULL)
                    {
                        grid_Save.passed_day = b.GetComponent<Dirt_Row>().Get_Planted_Crop().GetComponent<Crops>().passed_day;
                        grid_Save.plant_type = b.GetComponent<Dirt_Row>().plant_type;
                    }
                    else
                    {
                        grid_Save.passed_day = 0;
                        grid_Save.plant_type = ITEM_PLANT_TYPE.NULL;
                    }
                }
                inGameData.grid_Saves.Add(grid_Save);
            }
        }

    }
    public void Write()
    {
        SaveSystem.SavePlayer(inGameData.filename, inGameData);

    }
    public void Delete()
    {
        SaveSystem.DeletePlayer(inGameData.filename);
    }
    public void Load()
    {
        //가방 불러오기
        UI_Inventory uI_Inventory = FindObjectOfType<GameController>().ui_inventory;
        //uI_Inventory.inventory_Items_Plants = inGameData.items;
        try
        {
            for(int i = 0; i < uI_Inventory.inventory_Items_Plants.Length; i++)
            {
                uI_Inventory.inventory_Items_Plants[i].itemType = inGameData.items[i].itemType;
                uI_Inventory.inventory_Items_Plants[i].num = inGameData.items[i].num;
            }
            uI_Inventory.SetInventory();
            Debug.Log("Load inventory");
            }
        catch {
            Debug.Log("Load inventory failed");
        };
        try
        {
            SetQuest();
        }
        catch
        {
            Debug.Log("Load Quest failed");

        }
        try
        {
            if (SceneManager.GetActiveScene().name == "MyFarm")
            {
                GridSetting gridSetting = FindObjectOfType<GridSetting>();
                Farming_Control farming_Control = Resources.FindObjectsOfTypeAll<Farming_Control>()[0];
                if (farming_Control)
                {
                    foreach (Grid_Save g in inGameData.grid_Saves)
                    {
                        farming_Control.LoadBuilding(g);
                    }
                    Debug.Log("Load Building");
                }
                //작물 초기화
                Crops[] crops = FindObjectsOfType<Crops>();
                foreach (Crops c in crops)
                {
                    c.SetCrop();
                }
            }
        }
        catch
        {
            Debug.Log("Load Building failed");

        }
    }

    public void SetQuest()
    {
        //퀘스트 불러오기
        Quest[] quests = FindObjectOfType<QuestController>().quests;
        foreach (Quest_Save q in inGameData.quests)
        {
            quests[q.Quest_num].quest_state = q.quest_state;
        }
        Debug.Log("Load Quest");
    }

}
