using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPos : MonoBehaviour
{
    public string BeforeScene;
    public Transform character;
    // Start is called before the first frame update
    void Start()
    {
        if (FindObjectOfType<CharacterData>())
        {
            if(BeforeScene == FindObjectOfType<CharacterData>().BeforeScene)
            {
                character.transform.position = transform.position;
                character.transform.rotation = transform.rotation;
            }

        }
    }

}
