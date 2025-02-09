using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public GameObject NameInputField;
    public TMP_Text HighScorePlayerNameText;
    public TMP_Text HighScoreText;
    public static MenuManager Instance;

    // Start is called before the first frame update
    void Start()
    {
        MenuManager.Instance.LoadPlayerInfo();
        HighScorePlayerNameText.text = MenuManager.Instance.HighScorePlayerName;
        HighScoreText.text = MenuManager.Instance.HighScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartNew()
    {
        if(NameInputField.GetComponent<TMP_InputField>().text != "")
        {
            MenuManager.Instance.CurrentPlayerName = NameInputField.GetComponent<TMP_InputField>().text;
        }
        else
        {
            MenuManager.Instance.CurrentPlayerName = "Anonimo";
        }
        
        MenuManager.Instance.CurrentScore = 0; 
        //Debug.Log(" Nombre: " +NameInputField.GetComponent<TMP_InputField>().text );
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        //MainManager.Instance.SaveColor(); 

        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit(); // original code to quit Unity player
        #endif
    }

    public void SaveHighScore()
    {
        //MainManager.Instance.SaveColor();
    }

    public void HighScore()
    {
        //MainManager.Instance.LoadColor();
        //ColorPicker.SelectColor(MainManager.Instance.TeamColor);
    }
}
