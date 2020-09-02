using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ACT_BUTTON_STATE
{
    DISABLE, ACT_TREE, ACT_ROCK
};
public class GameController : MonoBehaviour
{
    public Transform spawnpos;
    public Transform character;
    public GameObject axeButton;
    public GameObject spadeButton;
    public GameObject loadingScreen;
    public GetLine ui_script;
    public CharacterSetting characterSetting;
    public UI_Inventory ui_inventory;
    private GameObject collectableObject;
    private ACT_BUTTON_STATE actButtonState;
    //public SaveData saveData;
    // Start is called before the first frame update
    void Start()
    {        
       
    }
    private void Awake()
    {
        character.transform.position = spawnpos.position;
        character.rotation = spawnpos.rotation;
        actButtonState = ACT_BUTTON_STATE.DISABLE;
        ui_inventory.SetInventory();
        try
        {
            characterSetting.SetCharacter();
        }
        catch(System.Exception e)
        {
            Debug.Log(e);
        }
        //loadingScreen.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetActButton(CollectableType value)
    {
        switch (value)
        {
            case CollectableType.TREE:
                actButtonState = ACT_BUTTON_STATE.ACT_TREE;
                axeButton.SetActive(true);
                spadeButton.SetActive(false);
                break;
            case CollectableType.ROCK:
                actButtonState = ACT_BUTTON_STATE.ACT_ROCK;
                axeButton.SetActive(false);
                spadeButton.SetActive(true);
                break;
        }
    
    }
    public void DisableActButton()
    {
        actButtonState = ACT_BUTTON_STATE.DISABLE;
        axeButton.SetActive(false);
        spadeButton.SetActive(false);
    }
    public void SetTryObject(GameObject gameObject)
    {
        collectableObject = gameObject;
    }
    public void ReleaseTryObject()
    {
        collectableObject = null;
    }
    public void Try()
    {
        collectableObject.GetComponent<CollectableObject>().Try();
    }
}
