using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotReady : Line
{
    // Start is called before the first frame update
    void Start()
    {
        
     }
    public override void SetScripts()
    {
        lines.Add("아직 이곳으로 가기에는 너무 이르다.");
        lines.Add("나중에 다시오자.");
        Debug.Log("NotReady");
        getline.SetScripts(lines);

    }

}
