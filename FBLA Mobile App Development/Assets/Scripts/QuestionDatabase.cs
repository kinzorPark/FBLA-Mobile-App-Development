﻿using System.Collections.Generic;
using UnityEngine;

/* ===========================
 * Question Database Class
 * ===========================
 * This static class loads all the questions from a csv files stored in format
 * 
 * Question, Choice1, Choice2, Choice3, Choice4, Answer, Category
 * 
 * Category are in integer format
 * CompetitveEvents = 1
 * BusinessSkills = 2
 * AboutFBLA = 3
 * FBLAHistory = 4
 * NationalOfficers = 5
 * 
 * IMPORTANT: At the start of program, run import game function with parameter of text file path
 * 
 */
public static class QuestionDatabase
{
    // Stores all questions, choices, answer, and type of every questions
    public static List<string> questions;
    public static List<string> choice1s;
    public static List<string> choice2s;
    public static List<string> choice3s;
    public static List<string> choice4s;
    public static List<string> answers;
    public static List<string> categories;

    // Load Questions from a CSV file for easy access
    public static void ImportGame(string path)
    {
        TextAsset qs = Resources.Load<TextAsset>(path);
        //Debug.Log(qs.text);

        // Split lines for each question
        string[] data = qs.text.Split('\n');

        // Initialize all lists
        questions = new List<string>();
        choice1s = new List<string>();
        choice2s = new List<string>();
        choice3s = new List<string>();
        choice4s = new List<string>();
        answers = new List<string>();
        categories = new List<string>();

        //Debug.Log("Total Questions: " + data.Length);

        // Go through each question and add it
        for (int i = 1; i < data.Length - 1; i++)
        {
            // Using | as a delimiter
            string[] row = data[i].Split('|');

            // Add all question components
            questions.Add(row[0].ToString());
            choice1s.Add(row[1].ToString());
            choice2s.Add(row[2].ToString());
            choice3s.Add(row[3].ToString());
            choice4s.Add(row[4].ToString());
            answers.Add(row[5].ToString());
            categories.Add(row[6].ToString());
        }
    }

}
