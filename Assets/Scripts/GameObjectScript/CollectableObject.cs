using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum CollectableType
{
    TREE, ROCK
};
public class CollectableObject : Building_Object
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
    /*
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            FindObjectOfType<GameController>().SetActButton(collectableType);
            FindObjectOfType<GameController>().SetTryObject(gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<GameController>().DisableActButton();
            FindObjectOfType<GameController>().ReleaseTryObject();
        }
    }
    */
    public void Try()
    {
        trytime--;
        if (trytime == 0)
        {
            Debug.Log(gameObject.name+" Trytime: " + trytime);
            //collectable object 획득

            Destroy(gameObject);
        }
    }
    
    public void Selected()
    {
        GetComponent<Outline>().enabled = true;
    }
    public void UnSelected()
    {
        GetComponent<Outline>().enabled = false;
    }
}
