using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public string scene;
    private LevelLoader levelLoader;
    // Start is called before the first frame update
    void Start()
    {
        levelLoader = FindObjectOfType<LevelLoader>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("TriggerEnter");
        if (other.tag == "Player")
        {
            if(!levelLoader)
                levelLoader = FindObjectOfType<LevelLoader>();
            if (FindObjectOfType<CharacterData>())
            {
                FindObjectOfType<CharacterData>().BeforeScene = SceneManager.GetActiveScene().name;
                FindObjectOfType<TimeController>().SaveTime();
            }
                levelLoader.LoadLevel(scene);

        }
    }
}
