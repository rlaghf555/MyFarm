using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterType
{
    Male_1,Male_2,Male_3,Female_1,Female_2
};
public enum CharacterMaterial
{
    A1,A2,A3,A4,B1,B2,B3,B4,C1,C2,C3,C4
};
[System.Serializable]
public class SaveData 
{
    public int onHead;
    public int characterMesh;
    public int characterMaterial;
    public UI_ITEM_PLANT_INFO[] items = new UI_ITEM_PLANT_INFO[(int)UI_ITEM_PLANT_TYPE.WATERMELON]; 
}
