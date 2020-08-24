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
    private int nowmesh=0;//for test
    // Start is called before the first frame update
    void Start()
    {
       // StartCoroutine("RandomCharacter");
    }
    IEnumerator RandomCharacter()
    {
        yield return new WaitForSeconds(2.0f);
        for (int i = 1; i < onHead.Length; i++)
            onHead[i].SetActive(false);

        onHead[Random.Range(1, onHead.Length - 1)].SetActive(true);
        skinnedMeshRenderer.sharedMesh = characterMesh[nowmesh];
        nowmesh++;
        if (nowmesh == characterMesh.Length)
            nowmesh = 0;
        skinnedMeshRenderer.material = materials[Random.Range(0,materials.Length-1)];
        StartCoroutine("RandomCharacter");

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
