using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCharacterButton : MonoBehaviour
{
    // Start is called before the first frame update
    public MenuController menuController;
    public CharacterCreator characterCreator;
    public GameObject createPanel;
    public string filename;
    private void OnMouseDown()
    {
        RaycastHit hit;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Physics.Raycast(ray, out hit);


        if (hit.collider != null)

        {

            if(hit.collider == this.GetComponent<BoxCollider>())
            {
                menuController.SetCameraPosToCharacterCreatePos();
                characterCreator.filename = filename;
                createPanel.SetActive(true);
            }

        }
    }
}
