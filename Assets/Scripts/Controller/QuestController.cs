using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestController : MonoBehaviour
{
    public GameObject Quest_Panel;
    public Text Quest_Name_Text;
    public Text Quest_Text;
    public Image Quest_Client_Portrait;
    public Quest[] quests;
    public Sprite[] portraits;
    public GameObject Quest_List_Content;
    public GameObject Quest_Accept_Prefab;
    public GameObject Control_UI;
    public GameObject Quest_List;
    [SerializeField]
    private Vector2 Content_Size;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowQuest(int Quest_Num)
    {
        Quest_Name_Text.text = quests[Quest_Num].Kor_Name;
        Quest_Text.text = quests[Quest_Num].Kor_Text;
        Quest_Client_Portrait.sprite = portraits[quests[Quest_Num].End_Character];
        Control_UI.SetActive(false);
        Quest_List.SetActive(false);
        Quest_Panel.SetActive(true);
    }
    public void Set_Quest_List()
    {
        for(int i=0;i< Quest_List_Content.transform.childCount; i++)
        {
            Destroy(Quest_List_Content.transform.GetChild(i).gameObject);
        }
        int y = -30;
        foreach(Quest q in quests)
        {
            if (!q) { continue; }
            if(q.quest_state == QUEST_STATE.ACCEPT)
            {
                GameObject newObject = Instantiate(Quest_Accept_Prefab, Quest_List_Content.transform);
                Vector2 rectsize = Content_Size;
                Quest_List_Content.GetComponent<RectTransform>().sizeDelta = new Vector2(rectsize.x, rectsize.y + 85);
                Debug.Log(Quest_List_Content.GetComponent<RectTransform>().sizeDelta);
                Vector3 pos = new Vector3(-50, y, 0);
                y -= 85;

                newObject.GetComponent<RectTransform>().anchoredPosition = pos;
                newObject.GetComponent<Quest_Accepted>().Set_Quest(q);
            }
        }
    }
    public Line FindQuestLine(int CharacterNum)
    {
        Debug.Log("findquestline" +CharacterNum);
        //클리어 가능한가
        foreach(Quest q in quests)
        {
            if (q.quest_state == QUEST_STATE.ACCEPT)
            {
                if (q.End_Character == CharacterNum)
                {
                    if (q.Is_Quest_Clear())
                    {
                        q.quest_state = QUEST_STATE.CLEAR;
                        Debug.Log("Clear");
                        return q.end_line;
                    }
                }
            }
            else if (q.quest_state == QUEST_STATE.ABLE)
            {
                if (q.Start_Character == CharacterNum)
                {
                    q.quest_state = QUEST_STATE.ACCEPT;
                    Debug.Log("Accept");

                    return q.start_line;
                }
            }
        }
        Debug.Log("NULL");

        return null;
    }
}
