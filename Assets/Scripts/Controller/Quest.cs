using UnityEngine;
using System.Collections;

[System.Serializable]
public struct Quest_Content
{
    public ITEM_PLANT_TYPE Quest_Item;
    public int Required_Num;
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
    public QUEST_STATE quest_state;
    public bool Is_Quest_Clear()
    {
        foreach(Quest_Content qc in Quest_Contents)
        {

        }
        return true;
    }
}
