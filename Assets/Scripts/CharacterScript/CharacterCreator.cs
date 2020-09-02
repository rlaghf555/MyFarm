using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCreator : MonoBehaviour
{
    public GameObject[] onHead;
    public GameObject[] characterMesh;
    public Material[] materials;
    public int onHeadIndex;
    public int characterMeshIndex;
    public int materialIndex;
    public string filename;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 1; i < onHead.Length; i++)
        {
            onHead[i].SetActive(false);
        }
        for (int i = 1; i < characterMesh.Length; i++)
        {
            characterMesh[i].SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnheadIndexPlus()
    {
        onHeadIndex++;
        if (onHeadIndex == onHead.Length)
            onHeadIndex = 0;
        SetCharacter();
    }

    public void OnheadIndexMinus()
    {
        onHeadIndex--;
        if (onHeadIndex == -1)
            onHeadIndex = onHead.Length-1;
        SetCharacter();
    }
    public void CharacterMeshIndexPlus()
    {
        characterMeshIndex++;
        if (characterMeshIndex == characterMesh.Length)
            characterMeshIndex = 0;
        SetCharacter();
    }
    public void CharacterMeshIndexMinus()
    {
        characterMeshIndex-=1;
        if (characterMeshIndex == -1)
            characterMeshIndex = characterMesh.Length-1;
        SetCharacter();
    }
    public void MaterialIndexIndexPlus()
    {
        materialIndex++;
        if (materialIndex == materials.Length)
            materialIndex = 0;
        SetCharacter();
    }
    public void MaterialIndexIndexMinus()
    {
        materialIndex--;
        if (materialIndex == -1)
            materialIndex = materials.Length-1;
        SetCharacter();
    }
    public void SetCharacter()
    {
        for (int i = 1; i < onHead.Length; i++)
        {
            onHead[i].SetActive(false);
        }
        
        for (int i = 0; i < characterMesh.Length; i++)
        {
            characterMesh[i].SetActive(false);
        }
        if (onHeadIndex != 0)
            onHead[onHeadIndex].SetActive(true);
        
        characterMesh[characterMeshIndex].SetActive(true);

        characterMesh[characterMeshIndex].GetComponent<SkinnedMeshRenderer>().material = materials[materialIndex];

    }
    public void CreateCharacter()
    {
        SaveData saveData = new SaveData();
        saveData.onHead = onHeadIndex;
        saveData.characterMesh = characterMeshIndex;
        saveData.characterMaterial = materialIndex;
        saveData.filename = filename;
        SaveSystem.SavePlayer(filename, saveData);
    }
}
