using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void Options()
    {
        SceneManager.LoadScene("OptionsMenu");
    }

    public void Exit()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}
