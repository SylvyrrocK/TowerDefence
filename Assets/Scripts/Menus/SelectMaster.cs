using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class SelectMaster : MonoBehaviour
{
    public string selectedLevel;

    public SceneFader sceneFader;

    public void LevelSelect(string selectedLevel)
    {
        sceneFader.FadeTo(selectedLevel);
        //SceneManager.LoadScene(selectedLevel);
    }

    public void Menu()
    {
        sceneFader.FadeTo("MainMenu");
        //SceneManager.LoadScene("MainMenu");
    }
}
