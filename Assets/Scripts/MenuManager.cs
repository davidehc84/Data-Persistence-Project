using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class MenuManager : MonoBehaviour
{
    
    public static MenuManager Instance;
    public String CurrentPlayerName;
    public int CurrentScore;
    public String HighScorePlayerName;
    public int HighScore;

    public TMP_Text HighScorePlayerNameText;
    public TMP_Text HighScoreText;
    public TMP_Text HighScoreDisplay;

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
    }
    
    // Start is called before the first frame update
    void Start()
    {
 //Debug.Log(Application.persistentDataPath);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


     [System.Serializable]
    class SaveData
    {
        public String HighScorePlayerName;
        public int HighScore;
    }

    public void CheckHighScore()
    {
        if(CurrentScore > HighScore)
        {
            HighScorePlayerName = CurrentPlayerName;
            HighScore = CurrentScore;
            //HighScoreDisplay.text = "High Score: "+ MenuManager.Instance.HighScorePlayerName+ " - "+ MenuManager.Instance.HighScore;
            SavePlayerInfo();
        }
    }

    public void SavePlayerInfo()
    {
        SaveData data = new SaveData();
        data.HighScorePlayerName = CurrentPlayerName;
        data.HighScore = CurrentScore;

        string json = JsonUtility.ToJson(data);
    
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadPlayerInfo()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            HighScorePlayerName = data.HighScorePlayerName;
            HighScore = data.HighScore;
        }
    }
}
