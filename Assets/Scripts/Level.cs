using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public static Level instance = null;//Static instance of Level which allows it to be accessed by any other script.
    private int level = 3;
    private int score;

    //singleton = create one instance in the whole game, each team an object level tries to awake we destroy it unless its the first one
    private void Awake()
    {
        //set canva score
        score = 0;

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
        SceneManager.LoadScene("GameOver");
    }
    public void LoadStarMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
    public void QuitGame()
    {
        //quit game
    }


    public void addScore(int point)
    {
        this.score += point;
        //set canva score
    }
    

}
