using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum CollectableType
{
    TREE, ROCK
};
public class CollectableObject : MonoBehaviour
{
    public CollectableType collectableType;
    public int trytime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            FindObjectOfType<GameController>().SetActButton(collectableType);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<GameController>().DisableActButton();
        }
    }
}
