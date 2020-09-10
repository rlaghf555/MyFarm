using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveAxe : Line
{
    void Start()
    {
        getline = FindObjectOfType<GameController>().ui_script;
    }
    
    override public void korLine()
    {
        lines.Add("오늘 부터 이웃이 된 친구가 자네로군? 반가워.");
        lines.Add("아직 무엇을 할지 모르는 눈치야.");
        lines.Add("내 남는 도끼를 하나 주도록 하지.");
        lines.Add("일단 자네 집 주변의 나무를 베게나.");
        lines.Add("처음엔 힘들겠지만 자네의 농장이 커져가는 걸 보면 뿌듯할게야.");
    }


}
