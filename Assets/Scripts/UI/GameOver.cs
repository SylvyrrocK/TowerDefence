using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    [Header ("UI Text:")]
    public TextMeshProUGUI wavesText;
    public TextMeshProUGUI scoreText;

    public SceneFader sceneFader;

    private void OnEnable()
    {
        wavesText.text = PlayerStats.waves.ToString();
        scoreText.text = PlayerStats.score.ToString();
    }

    public void Restart()
    {
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
        // Loads currently active scene again by calling its index
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Exit()
    {
        Time.timeScale = 1;
        sceneFader.FadeTo("MainMenu");
        //SceneManager.LoadScene("MainMenu");
    }
}
