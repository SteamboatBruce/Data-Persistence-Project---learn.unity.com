using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    [NonSerialized]
    public HighScoreData highScoreData = new HighScoreData();

    [Serializable]
    public class HighScoreData
    {
        public int highScore;
        public string playerName;
    }

    [NonSerialized]
    public string playerName;

    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadHighScoreData();
    }

    public void SaveHighScoreData()
    {
        
        string json = JsonUtility.ToJson(highScoreData);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScoreData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            if (json.Length > 0)
            {
                highScoreData = JsonUtility.FromJson<HighScoreData>(json);
            }
        }
    }

    private void OnApplicationQuit()
    {
        SaveHighScoreData();
    }

}
