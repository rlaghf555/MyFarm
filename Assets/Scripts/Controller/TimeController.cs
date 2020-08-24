using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    private Text timeText;
    [SerializeField] private float secondPerRealtimeSecond;
    [SerializeField] private float startTime;
    [SerializeField] private float endTime;
    private float nowTime;
    // Start is called before the first frame update
    void Start()
    {
        timeText=GameObject.Find("Time").GetComponent<Text>();
        nowTime = startTime;
    }
    private void FixedUpdate()
    {
        nowTime += secondPerRealtimeSecond * Time.deltaTime;
        int tmpTime = (int)nowTime;

        if (tmpTime / 3600 < 12)
        {
            string time = (tmpTime / 3600).ToString();
            string minute = (tmpTime % 3600 / 60).ToString();
            if (tmpTime / 3600 / 10<1)
            {
                time = "0" + time;
            }
            if (tmpTime % 3600 / 600<1)
            {
                minute = "0" + minute;
            }
            timeText.text = time + ":" + minute + "AM";
        }
        else
        {
            string time = (tmpTime / 3600-12).ToString();
            string minute = (tmpTime % 3600 / 60).ToString();
            if ((tmpTime / 3600 - 12) / 10 < 1)
            {
                time = "0" + time;
            }
            if (tmpTime % 3600 / 600 < 1)
            {
                minute = "0" + minute;
            }
            timeText.text = time + ":" + minute + "PM";
        }
        if (tmpTime > endTime)
            NextDay();

    }
   
    public void NextDay()
    {
        nowTime = startTime;
        Crops[] crops = FindObjectsOfType<Crops>();
        foreach(Crops c in crops)
        {
            c.passed_day++;
            c.SetCrop();
        }
    }
}
