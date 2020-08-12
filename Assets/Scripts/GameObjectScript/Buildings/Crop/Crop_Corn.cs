using UnityEngine;
using System.Collections;

public class Crop_Corn : Crops
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
            case 6:
            case 7:
                VegeRows.SetActive(false);
                foreach (GameObject t in CropPos)
                {
                    if (t.transform.childCount > 0)
                        Destroy(t.transform.GetChild(0).gameObject);
                    Instantiate(CropPrefabs[2], t.transform);
                }
                break;
            case 8:
            case 9:
                VegeRows.SetActive(false);
                foreach (GameObject t in CropPos)
                {
                    if (t.transform.childCount > 0)
                        Destroy(t.transform.GetChild(0).gameObject);
                    Instantiate(CropPrefabs[3], t.transform);
                }
                break;
            case 10:
                VegeRows.SetActive(false);
                foreach (GameObject t in CropPos)
                {
                    if (t.transform.childCount > 0)
                        Destroy(t.transform.GetChild(0).gameObject);
                    Instantiate(CropPrefabs[4], t.transform);
                }
                break;

        }
    }
}
