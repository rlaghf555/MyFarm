using UnityEngine;
using System.Collections;

public class QuestLine : Line
{
    public int[] Next_Quest_ABLE_Num;
    public int[] Next_Quest_ACCEPT_Num;

    public override void EndFunction()
    {
        Quest[] quests = FindObjectOfType<QuestController>().quests;

        foreach(Quest q in quests)
        {
            foreach(int i in Next_Quest_ABLE_Num)
            if(q.Quest_Num == i)
            {
                q.quest_state = QUEST_STATE.ABLE;
            }
        }
        foreach (Quest q in quests)
        {
            foreach (int i in Next_Quest_ACCEPT_Num)
                if (q.Quest_Num == i)
                {
                    q.quest_state = QUEST_STATE.ACCEPT;
                }
        }
    }
    
}
