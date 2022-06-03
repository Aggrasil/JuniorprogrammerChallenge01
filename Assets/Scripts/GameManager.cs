using System;
using System.Collections;
using System.Collections.Generic;
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
    //Singletonpattern for GameManger
    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
