using UnityEngine;
using System.Collections;

public enum CROP_TYPE
{
    CROP_ASPARAGUS
};
public class Dirt_Row : Building_Object
{
    public CROP_TYPE plant_type;
    [SerializeField]
    private GameObject[] Crops;
    private void Start()
    {
        Plant_Crop(CROP_TYPE.CROP_ASPARAGUS);
    }
    public void Plant_Crop(CROP_TYPE crop_type)
    {
        Instantiate(Crops[(int)crop_type], gameObject.transform.position, Quaternion.identity);
    }
}
