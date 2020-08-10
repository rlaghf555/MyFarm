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
    public virtual void SetCrop()
    {

    }
    

}
