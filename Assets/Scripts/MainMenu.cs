using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public string pickedLevel;

    public void Start()
    {
        pickedLevel = "FirstLevel";
    }

    public void Play()
    {
        SceneManager.LoadScene(pickedLevel);
    }

    public void Options()
    {
        Debug.Log("Options");
    }

    public void Exit()
    {
        Debug.Log("Exit");
        Application.Quit();
    }

}
