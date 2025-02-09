using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class MainUIHandler : MonoBehaviour
{
    public TMP_Text HighScore;
    // Start is called before the first frame update
    void Start()
    {
        LoadHighScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadHighScore()
    {
        HighScore.text = "High Score: "+ MenuManager.Instance.HighScorePlayerName+ " - "+ MenuManager.Instance.HighScore;
    }

    public void BackToMenu()
    {
        MenuManager.Instance.LoadPlayerInfo();
        SceneManager.LoadScene(0);
    }
}
