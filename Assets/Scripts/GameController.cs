using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Transform spawnpos;
    public Transform character;

    // Start is called before the first frame update
    void Start()
    {
        character.transform.position = spawnpos.position;
        character.rotation = spawnpos.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
