using UnityEngine;
using System.Collections;

[System.Serializable]
public struct Quest_Content
{
    public ITEM_PLANT_TYPE Quest_Item;
    public int Num;
}
[System.Serializable]
public enum QUEST_STATE
{
    DISABLE,ABLE,ACCEPT,CLEAR
}
[System.Serializable]
public class Quest : MonoBehaviour
{
    public int Quest_Num;
    public string Kor_Name;
    public string Eng_Name;
    [TextArea]
    public string Kor_Text;
    [TextArea]
    public string Eng_Text;
    [Tooltip("퀘스트 시작 캐릭터")]
    public int Start_Character;
    [Tooltip("퀘스트 완료 캐릭터")]
    public int End_Character;
    public Quest_Content[] Quest_Contents;
    public Quest_Content Return_Item;
    public int Return_Gold;
    public QUEST_STATE quest_state;
    public Line start_line;
    public Line end_line;
    public bool Is_Quest_Clear()
    {
        int contents_num = Quest_Contents.Length;
        int check_num = 0;
        foreach (Quest_Content qc in Quest_Contents)
        {
            UI_ITEM_PLANT_INFO[] inventory = FindObjectOfType<CharacterData>().inGameData.items;
            for(int i = 0; i < inventory.Length; i++)
            {
                if(qc.Quest_Item == inventory[i].itemType) // 퀘스트 아이템 확인
                {
                    if (qc.Num <= inventory[i].num) //퀘스트 아이템 갯수 확인
                    {
                        check_num++;
                        break;
                    }
                }
            }
        }
        if (contents_num == check_num)
        {
            return true;
        }
        else return false;

    }
    public void QuestClear()
    {

    }
}
