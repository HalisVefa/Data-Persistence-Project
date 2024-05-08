using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public string PlayerName;
    public string BestPlayerName;
    public int BestScore = 0;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadPlayerName();
        LoadBestPlayer();
    }

    [System.Serializable]
    class SaveData
    {
        public string PlayerName;
    }

    public void SavePlayerName()
    {
        SaveData data = new SaveData();
        data.PlayerName = PlayerName;

        string json = JsonUtility.ToJson(data);
    
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadPlayerName()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            PlayerName = data.PlayerName;
        }
    }

    [System.Serializable]
    class SaveBest
    {
        public string BestPlayerName;
        public int BestScore;
    }

    public void SaveBestPlayer()
    {
        SaveBest data = new SaveBest();
        data.BestPlayerName = BestPlayerName;
        data.BestScore = BestScore;

        string json = JsonUtility.ToJson(data);
    
        File.WriteAllText(Application.persistentDataPath + "/savefile1.json", json);
    }

    public void LoadBestPlayer()
    {
        string path = Application.persistentDataPath + "/savefile1.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveBest data = JsonUtility.FromJson<SaveBest>(json);

            BestPlayerName = data.BestPlayerName;
            BestScore = data.BestScore;
        }
    }
}
