using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Build : MonoBehaviour
{
    public BUILD_OBJECT build_object;
    public string Kor_Name;
    public string Eng_Name;
    [TextArea]
    public string Kor_Text;
    [TextArea]
    public string Eng_Text;
    // Start is called before the first frame update
    public void onclick()
    {
        FindObjectOfType<Farming_Control>().FarmBuildSetting(build_object);
    }
    public void SetBuildInfo()
    {

        GameObject.Find("Build Name").GetComponent<Text>().text = Kor_Name;
        GameObject.Find("Build Text").GetComponent<Text>().text = Kor_Text;

    }
}
