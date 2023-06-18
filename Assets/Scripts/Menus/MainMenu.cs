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

    public void OpenSteamProfile()
    {
        Application.OpenURL("https://steamcommunity.com/id/Sylvyrrock/");
    }

    public void Options()
    {
        SceneManager.LoadScene("OptionsMenu");
    }

    public void Achievemnets()
    {
        SceneManager.LoadScene("Achievements");
    }

    public void Exit()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}
