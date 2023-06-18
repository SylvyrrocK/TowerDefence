using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
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


    enum Speed
    {
        first = 1,
        second = 2,
        third = 4
    }

    Dictionary<int, float> dict = new Dictionary<int, float>()
    {
    {1, 0.5f},
    {2, 1},
    {3, 2}
    };


    int counter {get; set;} = 0;

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

        // TODO: Move it to InputHandler
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Pause))
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
        pauseUI.SetActive(false);
        Time.timeScale = 1;
    }

    public void changeTimeScale()
    {
            if (Time.timeScale == 1.0f)
        {
            Time.timeScale = 2f;
            Debug.Log("2");
        }
            else if (Time.timeScale == 2f)
        {
            Time.timeScale = 0.5f;
            Debug.Log("0.5");
        }
        else 
        {
            Time.timeScale = 1f;
            Debug.Log("1");
        }
  
    }

    void EndGame ()
    {
        gameOver = true;
        gameOverHUD.SetActive(true);
        inGameHUD.SetActive(false);
        //Debug.Log("GG");
    }
}
