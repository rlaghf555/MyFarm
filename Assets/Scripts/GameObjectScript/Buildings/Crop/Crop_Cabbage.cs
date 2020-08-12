using UnityEngine;
using System.Collections;

public class Crop_Cabbage : Crops
{
    //private void Update()
    //{
    //    SetCrop(passed_day);
    //}
    private void Start()
    {
        
    }
    private void OnEnable()
    {
        SetCrop();
    }
    public override void SetCrop()
    {
        switch (passed_day)
        {
            case 0:
                VegeRows.SetActive(true);
                break;
            case 1:
            case 2:
                {
                    VegeRows.SetActive(false);
                    foreach (GameObject t in CropPos)
                    {
                        if (t.transform.childCount > 0)
                            Destroy(t.transform.GetChild(0).gameObject);
                        Instantiate(CropPrefabs[0], t.transform);
                    }
                }
                break;
            case 3:
            case 4:
                {
                    VegeRows.SetActive(false);
                    foreach (GameObject t in CropPos)
                    {
                        if (t.transform.childCount > 0)
                            Destroy(t.transform.GetChild(0).gameObject);
                        Instantiate(CropPrefabs[1], t.transform);
                    }
                }
                break;
            case 5:
                VegeRows.SetActive(false);
                foreach (GameObject t in CropPos)
                {
                    if (t.transform.childCount > 0)
                        Destroy(t.transform.GetChild(0).gameObject);
                    Instantiate(CropPrefabs[2], t.transform);
                }
                break;

        }
    }
}
