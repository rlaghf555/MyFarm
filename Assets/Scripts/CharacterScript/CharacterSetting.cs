using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSetting : MonoBehaviour
{
    private SaveData saveData;
    public SkinnedMeshRenderer skinnedMeshRenderer;
    public GameObject[] onHead;
    public Mesh[] characterMesh;
    public Material[] materials;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void SetCharacter()
    {
        saveData= GameObject.Find("CharacterData").GetComponent<CharacterData>().inGameData;
        for (int i = 1; i < onHead.Length; i++)
            onHead[i].SetActive(false);
        if (saveData.onHead != 0)
            onHead[saveData.onHead].SetActive(true);
        skinnedMeshRenderer.sharedMesh = characterMesh[saveData.characterMesh];
        skinnedMeshRenderer.material = materials[saveData.characterMaterial];
        //skinnedMeshRenderer.sharedMesh;
       // skinnedMeshRenderer.material;
    }
   
}
