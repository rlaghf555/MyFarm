using UnityEngine;
using System.Collections;


public class Dirt_Row : Building_Object
{
    public ITEM_PLANT_TYPE plant_type;
    [SerializeField]
    private GameObject[] Crops;
    [SerializeField]
    private Transform Crop_Pos;
    private GameObject Planted_Crop;
    private void Start()
    {
    }
    public void Plant_Crop(ITEM_PLANT_TYPE crop_type)
    {
        Planted_Crop = Instantiate(Crops[(int)crop_type], Crop_Pos.position, Quaternion.identity,Crop_Pos);
    }
    public void DestroyCrop()
    {
        Destroy(Planted_Crop);
    }
    public GameObject Get_Planted_Crop()
    {
        return Planted_Crop;
    }
}
