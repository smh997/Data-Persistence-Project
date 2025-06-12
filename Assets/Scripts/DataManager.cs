using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance { get; private set; }

    public BestScoresData bestScoresData;

    public string currentPlayer;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // Ensure that this GameObject persists across scene loads
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadBestScore();
    }

    [Serializable]
    public class BestScoresData
    {
        public string playerName;
        public int playerScore;
    }

    public void SaveBestScore(int playerScore)
    {
        bestScoresData.playerName = currentPlayer;
        bestScoresData.playerScore = playerScore;
        // Here you can add code to save this data to a file or database if needed
        string json = JsonUtility.ToJson(bestScoresData);
        File.WriteAllText(Application.persistentDataPath + "/bestScore.json", json);
    }

    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/bestScore.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            bestScoresData = JsonUtility.FromJson<BestScoresData>(json);
            currentPlayer = bestScoresData.playerName;
        }
        else
        {
            bestScoresData = new BestScoresData { playerName = "No Name", playerScore = 0 };
        }
    }
}
