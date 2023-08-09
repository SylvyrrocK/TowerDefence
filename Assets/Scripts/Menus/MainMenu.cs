using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public SceneFader sceneFader;

    public void Play()
    {
        sceneFader.FadeTo("LevelSelect");
        //SceneManager.LoadScene("LevelSelect");
    }

    public void OpenSteamProfile()
    {
        Application.OpenURL("https://steamcommunity.com/id/Sylvyrrock/");
    }

    public void Options()
    {
        sceneFader.FadeTo("OptionsMenu");
        //SceneManager.LoadScene("OptionsMenu");
    }

    public void Achievemnets()
    {
        sceneFader.FadeTo("Achievements");
        //SceneManager.LoadScene("Achievements");
    }

    public void Exit()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}
