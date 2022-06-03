using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif




[DefaultExecutionOrder(1000)]
public class GameManager : MonoBehaviour
{
    //Variables
    private static GameManager instance;
    private static string hsPlayername;
    private static int highScore;
    private static string actualPlayername;
    //Variables end
    //Instance property
    public static GameManager Instance
    {
        get 
        { 
            return instance;
        }
        set
        {
            GameManager.instance = value;
        }
    }
    
    private void Awake()
    {
        //Singletonpattern for GameManger
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadHighscore();
        //Singleton end
    }
    [System.Serializable]
    class SaveData
    {
        public string hsPlayername;
        public int highscore;
    }
    
    public static void SaveHighscore()
    {
        SaveData data = new SaveData();
        data.hsPlayername = GameManager.hsPlayername;
        data.highscore = GameManager.highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighscore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            GameManager.hsPlayername = data.hsPlayername;
            GameManager.highScore = data.highscore;
        }
    }

    // Properties begin
    public static string ActualPlayername
    {
        get
        {
            return GameManager.actualPlayername;
        }
        set
        {
            GameManager.actualPlayername = value;
        }
    }
    public static string HsPlayername
    {
        get
        {
            return GameManager.hsPlayername;
        }
        set
        {
            GameManager.hsPlayername = value;
        }
    }

    public static int HighScore
    {
        get
        {
            return GameManager.highScore;
        }
        set
        {
            if(value > GameManager.highScore)
            {
                GameManager.highScore = value;
            }
        }
    }
    //Properties end

    public static void NewHighscore(int score)
    {
        GameManager.HsPlayername = GameManager.ActualPlayername;
        GameManager.HighScore = score;
        GameManager.SaveHighscore();
    }
}
