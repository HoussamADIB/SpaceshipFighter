using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


//This is a script to display health - score ...
public class Display : MonoBehaviour
{
    private GameObject Score;
    private TextMeshProUGUI scoreText;
    private GameManager instance;

    // Start is called before the first frame update
    void Start()
    {
        //instance is the singleton like a temporary session
        instance = FindObjectOfType<GameManager>();
        //Score in the game canva
        Score = GameObject.Find("Score");
        scoreText = Score.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Score != null && instance != null && scoreText!=null)
        {
            scoreText.text = instance.getScore().ToString();
        }
    }
}
