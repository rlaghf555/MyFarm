using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterType
{
    Male_1,Male_2,Male_3,Female_1,Female_2
};
public enum CharacterMaterial
{
    A1,A2,A3,A4,B1,B2,B3,B4,C1,C2,C3,C4
};
[System.Serializable]
public struct Quest_Save
{
    public int Quest_num;
    public QUEST_STATE quest_state;
}
[System.Serializable]
public struct Grid_Save
{
    public BUILD_OBJECT build_object;
    public int grid_x, grid_z;
    public int passed_day;
    public ITEM_PLANT_TYPE plant_type;
}
[System.Serializable]
public class SaveData 
{
    public int onHead;
    public int characterMesh;
    public int characterMaterial;
    public UI_ITEM_PLANT_INFO[] items = new UI_ITEM_PLANT_INFO[(int)ITEM_PLANT_TYPE.WATERMELON+1];
    public string filename;
    public List<Quest_Save> quests;
    public List<Grid_Save> grid_Saves;
    public SaveData()
    {
        quests = new List<Quest_Save>();
        grid_Saves = new List<Grid_Save>();
    }
}
