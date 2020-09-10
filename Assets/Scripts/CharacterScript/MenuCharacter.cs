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
    public GameObject openSceneButton;
    private void Start()
    {
        Load();
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
            Debug.Log(filename + "로드 완료");
            onHeadIndex = saveData.onHead;
            characterMeshIndex = saveData.characterMesh;
            materialIndex = saveData.characterMaterial;
            if(onHeadIndex!=0)
            onHead[onHeadIndex].SetActive(true);
            characterMesh[characterMeshIndex].SetActive(true);
            characterMesh[characterMeshIndex].GetComponent<SkinnedMeshRenderer>().material = materials[materialIndex];
            createCharacterButton.SetActive(false);
            openSceneButton.SetActive(true);
            openSceneButton.GetComponent<OpenSceneButton>().savedata = saveData;
        }
    }
}
