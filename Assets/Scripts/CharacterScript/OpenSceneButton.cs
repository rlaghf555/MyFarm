using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenSceneButton : MonoBehaviour
{
    public string scenename;
    public SaveData savedata;
    // Start is called before the first frame update

    private void OnMouseDown()
    {
        RaycastHit hit;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Physics.Raycast(ray, out hit);


        if (hit.collider != null)

        {

            if (hit.collider == this.GetComponent<BoxCollider>())
            {
                GetComponent<LevelLoader>().LoadLevel(scenename);
                GameObject newgameObject = GameObject.FindGameObjectWithTag("Data");
                newgameObject.GetComponent<CharacterData>().inGameData = savedata;
                DontDestroyOnLoad(newgameObject);
            }

        }
    }
   
}
