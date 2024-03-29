﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;//Static instance of GameManager which allows it to be accessed by any other script.
    //private int level;
    [SerializeField] int score;
    GameObject FinalScore;
    //singleton = create one instance in the whole game, each team an object level tries to awake we destroy it unless its the first one
    private void Awake()
    {
        //set canva score
        score = 0;


        GameData data = SaveSystem.loadData();
        if (data != null)
        {
            Debug.Log("DATA LOADED = " + data.maxScore);
            score = data.maxScore;
        }
        else
        {
            Debug.Log("DATA LOADED is null");
        }


        //Check if instance already exists
        if (instance == null)   instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)  Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
    }
    //--------------------------------------------------------------Functions
    public void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void LoadGameOver()
    {
        GameData data = new GameData(score);
        SaveSystem.saveData(data);
        Debug.Log("SAVING DATA . . . .");
        SceneManager.LoadScene("GameOver");

        Invoke("SetFinalScore", 0.1f );
        
    }
    private void SetFinalScore()
    {
        FinalScore = GameObject.Find("Final Score");
        if (FinalScore != null)
        {
            TextMeshProUGUI scoreText = FinalScore.GetComponent<TextMeshProUGUI>();
            scoreText.text = getScore().ToString();
        }
        else
        {
            Debug.Log("Final Score is null . . .");
        }
    }


    public void LoadStarMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
    public void QuitGame()
    {
        

        Application.Quit();
    }

    public int getScore()
    {
        return this.score;
    }

    public void addScore(int points)
    {
        this.score += points;
    }
    

}
