using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public GameObject loadingscreen;
    public Slider slider;
    public string scenename;
    public SaveData saveData;
    public void LoadGame(string scenename)
    {
        this.scenename = scenename;
        LoadGame();
    }
    public void LoadGame()
    {
        GetComponent<Animator>().SetTrigger("Fade_Out");
        GameObject newgameObject = GameObject.FindGameObjectWithTag("Data");
        newgameObject.GetComponent<CharacterData>().inGameData = saveData;
        DontDestroyOnLoad(newgameObject);
    }
    public void LoadLevel(string scenename)
    {
        this.scenename = scenename;
        GetComponent<Animator>().SetTrigger("Fade_Out");
    }
    public void SetSaveData(SaveData data)
    {
        saveData = data;
    }
    IEnumerator LoadAsynchronously(string scenename)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(scenename);
        
        while(!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            yield return null;
        }
    }
    public void OnFadeComplete()
    {
        //loadingscreen.SetActive(true);
       // StartCoroutine(LoadAsynchronously(scenename));
        SceneManager.LoadScene(scenename);
    }
}
