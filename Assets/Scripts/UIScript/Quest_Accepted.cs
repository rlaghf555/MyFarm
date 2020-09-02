using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest_Accepted : MonoBehaviour
{
    private QuestController questController;
    public Quest quest;
    public Image image;
    public Text quest_name;
    // Start is called before the first frame update
    void Start()
    {
    }
    public void Set_Quest(Quest q)
    {
        quest = q;
        questController = FindObjectOfType<QuestController>();
        image.sprite = questController.portraits[q.Start_Character];
        quest_name.text = q.Kor_Name;
        //quest_name.text = q.Eng_Name;
    }
    public void ShowQuest()
    {
        questController = FindObjectOfType<QuestController>();
        questController.ShowQuest(quest.Quest_Num);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
