using UnityEngine;
using System.Collections;

public class Crops : MonoBehaviour
{
    public int growth_day;
    [Range(0,10)]
    public int passed_day;
    public GameObject[] CropPrefabs;
    public GameObject[] CropPos;
    public GameObject VegeRows;
    public ITEM_PLANT_TYPE item_plant_type;
    public int ReturnValue;
    public string Kor_Name;
    public string Eng_Name;
    public virtual void SetCrop()
    {

    }
    

}
