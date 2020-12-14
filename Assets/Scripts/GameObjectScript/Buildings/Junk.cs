using UnityEngine;
using System.Collections;

public class Junk : Building_Object
{

   public void Remove()
    {
        CharacterData characterData = FindObjectOfType<CharacterData>();
        if (characterData.inGameData.gold >= 2000)
        {
            characterData.inGameData.gold -= 2000;
            FindObjectOfType<GameController>().farming_control.DestroyBuilding(this.GetComponent<Junk>());
            Destroy(gameObject);
        }
        else
        {
            FindObjectOfType<GameController>().JunkMessage_Resume.SetActive(true);
        }
    }

    
    
}
