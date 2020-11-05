using UnityEngine;
using System.Collections;

[System.Serializable]
public struct Quest_Content
{
    public ITEM_PLANT_TYPE itemType;
    public int num;
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
    [Tooltip("퀘스트 요구 아이템")]
    public Quest_Content[] Quest_Require_Contents;
    [Tooltip("퀘스트 요구 금액")]
    public int Quest_Require_Gold;
    [Tooltip("퀘스트 지급 아이템")]
    public Quest_Content[] Quest_Receive_Contents;
    [Tooltip("퀘스트 완료 보상 아이템")]
    public Quest_Content[] Quest_Return_Contents;
    [Tooltip("퀘스트 완료 보상 금액")]
    public int Return_Gold;
    public QUEST_STATE quest_state;
    public Line start_line;
    public Line end_line;
    public bool Is_Quest_Clear()
    {
        int contents_num = Quest_Require_Contents.Length;
        int check_num = 0;
        foreach (Quest_Content qc in Quest_Require_Contents)
        {
            UI_ITEM_PLANT_INFO[] inventory = FindObjectOfType<CharacterData>().inGameData.items;
            for(int i = 0; i < inventory.Length; i++)
            {
                if(qc.itemType == inventory[i].itemType) // 퀘스트 아이템 확인
                {
                    if (qc.num <= inventory[i].num) //퀘스트 아이템 갯수 확인
                    {
                        check_num++;
                        break;
                    }
                }
            }
        }
        if (contents_num == check_num)
        {
            if (Quest_Require_Gold <= FindObjectOfType<CharacterData>().inGameData.gold)
            {
                Debug.Log("Clear");
                return true;
            }
            else
            {
                Debug.Log("fail");

                return false;
            }
        }
        else
        {
            Debug.Log("fail");

            return false;
        }
    }
    public void QuestClear()//퀘스트 클리어시 호출
    {
        //퀘스트 요구사항


        //보상 수령
        foreach (Quest_Content qc in Quest_Return_Contents)
        {
            UI_ITEM_PLANT_INFO[] inventory = FindObjectOfType<CharacterData>().inGameData.items;
            for (int i = 0; i < inventory.Length; i++)
            {
                if (qc.itemType == inventory[i].itemType) 
                {
                    inventory[i].num += qc.num;
                    break;
                }
                if (inventory[i].itemType == ITEM_PLANT_TYPE.NULL)
                {
                    inventory[i].itemType = qc.itemType;
                    inventory[i].num = qc.num;
                    break;
                }
            }
        }
        FindObjectOfType<CharacterData>().inGameData.gold += Return_Gold;
    }
    public void QuestRecive()//퀘스트 받았을때 호출
    {
        
        foreach (Quest_Content qrc in Quest_Receive_Contents)
        {
            UI_ITEM_PLANT_INFO[] inventory = FindObjectOfType<CharacterData>().inGameData.items;
            for (int i = 0; i < inventory.Length; i++)
            {
                if (qrc.itemType == inventory[i].itemType) // 퀘스트 아이템 확인
                {
                    inventory[i].num+=qrc.num;
                    break;
                }
                if(inventory[i].itemType == ITEM_PLANT_TYPE.NULL)
                {
                    inventory[i].itemType = qrc.itemType;
                    inventory[i].num = qrc.num;
                    break;
                }
            }
        }
        
    }
}
