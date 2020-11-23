using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;

[System.Serializable]
public class GameSettingData
{
    public int qualityIndex;
    public float volume;
    public bool iskor;
}
public class GameSetting : MonoBehaviour
{
    public GameSettingData gameSettingData;
    // Start is called before the first frame update
    void Start()
    {
        Load();
    }

    public void Save()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "GameSetting.farm";

        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, gameSettingData);
        stream.Close();
        Debug.Log("GameSetting Save");

    }
    public void Load()
    {
        string path = Application.persistentDataPath + "GameSetting.farm";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameSettingData data = formatter.Deserialize(stream) as GameSettingData;
            stream.Close();
            QualitySettings.SetQualityLevel(data.qualityIndex);
            gameSettingData = data;
        }
        else
        {
            gameSettingData = new GameSettingData();
            gameSettingData.qualityIndex = 2;
            gameSettingData.volume = 0;
            gameSettingData.iskor = true;
            Save();
            Debug.LogError("Save file not found in " + path);
        }
        DontDestroyOnLoad(this);
        Debug.Log("GameSetting Load");

    }
}
