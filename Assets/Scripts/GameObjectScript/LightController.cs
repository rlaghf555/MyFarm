using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    [SerializeField] private float secondPerRealtimeSecond;
    public GameObject directionalLight;
    [SerializeField] private bool isNight = false;

    [SerializeField] private float fogDensityCalc;

    [SerializeField] private float nightFogDensity;

    private float dayFogDensity;
    private float currentFogDensity;
    // Start is called before the first frame update
    void Start()
    {
        dayFogDensity = RenderSettings.fogDensity;

    }

    // Update is called once per frame
    void Update()
    {
        directionalLight.transform.Rotate(Vector3.right, 0.1f * secondPerRealtimeSecond * Time.deltaTime);
        if (RenderSettings.fogColor == Color.white)
        {
            Debug.Log("White");
            return;
        }
        if (directionalLight.transform.eulerAngles.x >= 170)
        {
            isNight = true;
        }
        else if (directionalLight.transform.eulerAngles.x >= 0)
        {
            isNight = false;
        }
        if (isNight)
        {
            if (currentFogDensity <= nightFogDensity)
            {
                //RenderSettings.fogColor = Color.black;
                currentFogDensity += 0.01f * fogDensityCalc * Time.deltaTime;
                RenderSettings.fogDensity = currentFogDensity;
            }
        }
        else
        {
            if (currentFogDensity >= dayFogDensity)
            {
               // RenderSettings.fogColor = new Color(255,212,158);
                currentFogDensity -= 0.01f * fogDensityCalc * Time.deltaTime;
                RenderSettings.fogDensity = currentFogDensity;

            }
        }
       //Debug.Log("isnight:" + isNight);
       //Debug.Log("currentFogDensity:" + currentFogDensity);
       //Debug.Log("nightFogDensity:" + nightFogDensity);
       //Debug.Log("dayFogDensity:" + dayFogDensity);
        
    }

    public void Rotate(float x)
    {
        Quaternion newrotation = new Quaternion();
        newrotation = Quaternion.Euler(x, 0, 0);
        directionalLight.transform.rotation = newrotation;
    }
}
