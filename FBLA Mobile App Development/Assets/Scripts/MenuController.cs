﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

//static bool AudioBegin = false;

public class MenuController : MonoBehaviour
{
    /* ===========================
    * Question Database Class
    * ===========================
    * This class controls the start scene
    */

    [SerializeField]
    private GameObject startButton;
    [SerializeField]
    private GameObject instructionsButton;
    [SerializeField]
    private GameObject creditsButton; 
    [SerializeField]
    private GameObject bugMenu;
    [SerializeField]
    TMP_Text nameText;

    public static string username;

    // Loads leaderboard scene 
    public void Leaderboard()
    {
        SceneManager.LoadScene("Leaderboard");
    }

    public void Start()
    {
        nameText.text = "Name: " + username;
        // Always run the following in order

        // Imports questions to lists of strings from csv
        QuestionDatabase.ImportGame("fbla");
        // Load all the strings into lists of Question Set Objects organized by categories
        Questions.LoadAllQuestions();

    }
    // Called when Start Button is Pressed
    public void StartGame()
    {
        // Load the Scene to choose topic
        SceneManager.LoadScene("Topic");
    }

    // Called when Instructions button is Pressed
    public void Instructions()
    {
        // Open Instructions Scene
        SceneManager.LoadScene("Instructions");
    }

    // Called when Credits button is Pressed
    public void Credits()
    {
        // Open Credits Scene
        SceneManager.LoadScene("Credits");
    }

    // Update is called once per frame
    private void Update()
    {

        if (bugMenu.activeSelf == true)
        {
            startButton.GetComponent<Button>().enabled = false;
            creditsButton.GetComponent<Button>().enabled = false;
            instructionsButton.GetComponent<Button>().enabled = false;
        }
        else
        {
            startButton.GetComponent<Button>().enabled = true;
            creditsButton.GetComponent<Button>().enabled = true;
            instructionsButton.GetComponent<Button>().enabled = true;
        }
    }

    /*public class menuMusic : MonoBehaviour
    {
        private void Awake()
        {
            if (!AudioBegin)

        }
    }*/
}
