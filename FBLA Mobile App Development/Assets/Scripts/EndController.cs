﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class EndController : MonoBehaviour
{
    [SerializeField]
    private GameObject scoreText;
    [SerializeField]
    public GameObject highScore;

    public Button m_firstButton;

    [SerializeField]
    TMP_Text nameText;

    const string privateCode = "";
    const string publicCode = "";
    const string webUrl = "http://dreamlo.com/lb/fSJ0kZGVv0mxWHfmsF6fqASwUXyLPUE0KRhYaWOUzJ7Q";

    void Start()
    {
        nameText.text = "Name: " + MenuController.username;
        StartCoroutine(UploadNewHighScore(MenuController.username, (int)GameController.playerScore));
        scoreText.GetComponent<TextMeshProUGUI>().text = "Score: " + GameController.playerScore;
        HighScore((int)GameController.playerScore);
        Debug.Log("Uploading ");
        m_firstButton.onClick.AddListener(ResetGame);
        FindObjectOfType<MusicManager>().Stop("Gameplay");
        FindObjectOfType<MusicManager>().Stop("ThemeSong");
        FindObjectOfType<MusicManager>().Play("ThemeSong");
    }

    // Loads leaderboard scene 
    public void Leaderboard()
    {
        SceneManager.LoadScene("Leaderboard");
    }

    // Resets game after a loss or after 10 questions answered correctly
    void ResetGame()
    {
        // Load start screen
        SceneManager.LoadScene("Start");

        // Set score back to 0 for the new game 
        GameController.numCorrect = 0;
        GameController.playerScore = 0;

        //Reset question database
        for (int i = 0; i < Questions.questionsUsed.Count; i++)
        {
            Questions.questionsUsed[i].Used = false;
        }
    }

    public void Share()
    {
        NativeShare ns = new NativeShare();
        ns.SetTitle("Check Out This AWESOME Game");
        ns.SetText("I Just GOT " + GameController.numCorrect + " on the Fast Facts: FBLA QUIZ!!\n" +
            "https://github.com/kinzorPark/FBLA-Mobile-App-Development");
        ns.Share();
    }

    public void HighScore(int currScore)
    {
        if (currScore > PlayerPrefs.GetInt("highScore", 0))
        {
            Debug.Log("High Score updated from " + PlayerPrefs.GetInt("highScore", 0) + " to " + currScore);
            PlayerPrefs.SetInt("highScore", currScore);
        }

        else
        {
            Debug.Log("High Score stays same: " + PlayerPrefs.GetInt("highScore", 0));
        }

        highScore.GetComponent<TextMeshProUGUI>().text = "High Score: " + PlayerPrefs.GetInt("highScore", 0);



    }

    IEnumerator UploadNewHighScore(string username, int score)
    {
        Debug.Log("UploadNewHighScoreRun");
        Debug.Log(webUrl + "/add/" + WWW.EscapeURL(username) + "/" + score);
        WWW www = new WWW(webUrl + "/add/" + WWW.EscapeURL(username) + "/" + score);
        WWW www1 = new WWW("http://dreamlo.com/lb/fSJ0kZGVv0mxWHfmsF6fqASwUXyLPUE0KRhYaWOUzJ7Q/add/Carmine/100");
        yield return www;

        if (string.IsNullOrEmpty(www1.error))
        {
            Debug.Log("Upload successful");
        }

        else
        {
            Debug.Log("Upload failed");
        }
    }
}
