using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingUI : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject settingUI;
    public AudioMixer audioMixer;
    public Text QualityLabel;
    public Text LanguageLabel;
    public Slider slider;
    GameSetting gameSetting;
    // Start is called before the first frame update
    void Start()
    {
        gameSetting = FindObjectOfType<GameSetting>();
        gameSetting.Load();
    }
    private void OnEnable()
    {
        Set();

    }

    public void Pause()
    {
        settingUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void Resume()
    {
        settingUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        gameSetting.gameSettingData.qualityIndex = qualityIndex;
        gameSetting.Save();
    }
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        gameSetting.gameSettingData.volume = volume;
        gameSetting.Save();

    }
    public void SetLanguage(int language)
    {
        if (language == 0)
        {
            gameSetting.gameSettingData.iskor = true;
        }
        else if (language == 1)
        {
            gameSetting.gameSettingData.iskor = false;
        }
        gameSetting.Save();

    }

    void Set()
    {
        switch (gameSetting.gameSettingData.qualityIndex)
        {
            case 0:
                QualityLabel.text = "VERY LOW";
                break;
            case 1:
                QualityLabel.text = "LOW";
                break;
            case 2:
                QualityLabel.text = "MEDIUM";
                break;
            case 3:
                QualityLabel.text = "HIGH";
                break;
            case 4:
                QualityLabel.text = "VERY HIGH";
                break;
        }
        switch (gameSetting.gameSettingData.iskor)
        {
            case true:
                LanguageLabel.text = "Korean";
                break;
            case false:
                LanguageLabel.text = "English";
                break;
        }
        slider.value = gameSetting.gameSettingData.volume;
    }
}
