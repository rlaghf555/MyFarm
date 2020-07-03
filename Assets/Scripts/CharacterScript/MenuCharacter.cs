using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCharacter : MonoBehaviour
{
    public string filename;
    private SaveData saveData;
    public GameObject[] onHead;
    public GameObject[] characterMesh;
    public Material[] materials;
    public int onHeadIndex;
    public int characterMeshIndex;
    public int materialIndex;
    public GameObject createCharacterButton;
    // Start is called before the first frame update
    void Start()
    {
      

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Load()
    {
        saveData = SaveSystem.Load(filename);
        if (saveData == null)
        {
            return;
        }
        else
        {
            onHeadIndex = saveData.onHead;
            characterMeshIndex = saveData.characterMesh;
            materialIndex = saveData.characterMaterial;
            if(onHeadIndex!=0)
            onHead[onHeadIndex].SetActive(true);
            characterMesh[characterMeshIndex].SetActive(true);
            characterMesh[characterMeshIndex].GetComponent<SkinnedMeshRenderer>().material = materials[materialIndex];
            createCharacterButton.SetActive(false);
        }
    }
}
