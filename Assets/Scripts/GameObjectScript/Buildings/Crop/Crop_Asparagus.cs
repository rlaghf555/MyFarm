using UnityEngine;
using System.Collections;

public class Crop_Asparagus : Crops
{
   //private void Update()
   //{
   //    SetCrop(passed_day);
   //}
    public override void SetCrop()
    {
        switch (passed_day)
        {
            case 0:
            case 1:
                {
                    Vector3 newPos = transform.position;
                    newPos.y = -0.3f;
                    transform.position = newPos;
                }
                break;
            case 2:
            case 3:               
            case 4:
                {
                    Vector3 newPos = transform.position;
                    newPos.y = -0.15f;
                    transform.position = newPos;
                }
                break;
            case 5:
                {
                    Vector3 newPos = transform.position;
                    newPos.y = 0;
                    transform.position = newPos;
                }
                break;

        }
    }
}
