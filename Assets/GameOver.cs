using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI wavesText;
    public TextMeshProUGUI scoreText;

    private void OnEnable()
    {
        wavesText.text = PlayerStats.waves.ToString();
        scoreText.text = PlayerStats.score.ToString();
    }
}
