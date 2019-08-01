using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool gamePaused = false;
    [SerializeField] GameObject PauseMenuUI;
    [SerializeField] Player player;
    [SerializeField] Sprite blueSprite;
    [SerializeField] Sprite redSprite;
    [SerializeField] Sprite greenSprite;
    [SerializeField] Sprite orangeSprite;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            switchMenu();
        }
    }

    public void switchMenu()
    {
        if (gamePaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        gamePaused = false;
    }
    public void Pause()
    {
        HideJoystick();
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        gamePaused = true;
    }
    public void Quit()
    {
        Application.Quit();
    }

    private void HideJoystick()
    {
        player.circle.GetComponent<SpriteRenderer>().enabled = false;
        player.outerCircle.GetComponent<SpriteRenderer>().enabled = false;
    }

    public void Blue()
    {
        player.GetComponent<SpriteRenderer>().sprite = blueSprite;
    }public void Red()
    {
        player.GetComponent<SpriteRenderer>().sprite = redSprite;
    }public void Green()
    {
        player.GetComponent<SpriteRenderer>().sprite = greenSprite;
    }public void Orange()
    {
        player.GetComponent<SpriteRenderer>().sprite = orangeSprite;
    }
}
