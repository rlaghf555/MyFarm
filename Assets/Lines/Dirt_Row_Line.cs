using UnityEngine;
using System.Collections;

public class Dirt_Row_Line : Line
{
    private Dirt_Row dirt;
    void Start()
    {
        getline = FindObjectOfType<GameController>().ui_script;
        dirt = GetComponent<Dirt_Row>();
    }

    override public void korLine()
    {
        lines.Add("각종 작물을 심을 수 있는 밭");
        if(dirt.plant_type != ITEM_PLANT_TYPE.NULL)
        {
            Crops tmp_crop = dirt.Get_Planted_Crop().GetComponent<Crops>();
            string crop_name;
            crop_name= tmp_crop.Kor_Name;

            string tmp_line = crop_name + " 성장 완료까지 (" + tmp_crop.passed_day.ToString() + "/" + tmp_crop.growth_day.ToString() + ")";
            lines.Add(tmp_line);
        }

    }
    override public void engLine()
    {
        lines.Add("A field for planting various crops");
        if (dirt.plant_type != ITEM_PLANT_TYPE.NULL)
        {
            Crops tmp_crop = dirt.Get_Planted_Crop().GetComponent<Crops>();
            string crop_name;
            crop_name = tmp_crop.Kor_Name;

            string tmp_line = crop_name + " is growing (" + tmp_crop.passed_day.ToString() + "/" + tmp_crop.growth_day.ToString() + ")";
            lines.Add(tmp_line);
        }
    }

}
