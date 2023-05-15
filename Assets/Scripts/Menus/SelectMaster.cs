using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class SelectMaster : MonoBehaviour
{
    public string selectedLevel;

    public void LevelSelect(string selectedLevel)
    {
        SceneManager.LoadScene(selectedLevel);
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
