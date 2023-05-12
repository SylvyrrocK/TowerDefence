using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameContoller : MonoBehaviour
{
    [Header("UI Components:")]
    public GameObject gameOverHUD;
    public GameObject inGameHUD;
    public GameObject pauseUI;

    [Header("Game Status:")]
    public static bool gameOver;
    public static bool gameIsPaused;

    private void Start()
    {
        gameOver = false;
        gameIsPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            return;
        }

        if (PlayerStats.coreLives <= 0)
        {
            EndGame();
        }

        // Move it to InputHandler
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!gameIsPaused)
            {
                Debug.Log("PAUSE");
                gameIsPaused = !gameIsPaused;
                PauseGame();
            }
            else
            {
                Debug.Log("PLAY");
                gameIsPaused = !gameIsPaused;
                ResumeGame();
            }

        }

        //DELETE LATER
        if (Input.GetKeyDown("e"))
        {
            EndGame();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseUI.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseUI.SetActive(false);
    }

    void EndGame ()
    {
        gameOver = true;
        gameOverHUD.SetActive(true);
        inGameHUD.SetActive(false);
        //Debug.Log("GG");
    }
}
