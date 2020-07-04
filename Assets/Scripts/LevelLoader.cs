using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public GameObject loadingscreen;
    public Slider slider;
    public void LoadLevel(string scenename)
    {
        loadingscreen.SetActive(true);
        StartCoroutine(LoadAsynchronously(scenename));
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
}
