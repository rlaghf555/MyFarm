using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookCharacter : MonoBehaviour
{
    public Transform character;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 newVector = character.position;
        newVector.y = transform.position.y;
        transform.LookAt(newVector);

    }
}
