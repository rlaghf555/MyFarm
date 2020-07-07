using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenSceneButton : MonoBehaviour
{
    public SaveData savedata;
    public GameObject levelLoader;
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
                levelLoader.GetComponent<LevelLoader>().SetSaveData(savedata);
                levelLoader.GetComponent<LevelLoader>().LoadLevel();
                
            }

        }
    }
   
}
