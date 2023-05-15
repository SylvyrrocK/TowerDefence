using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    [Header("Player starting stats:")]
    public static int money;
    public int startMoney = 800;

    public static int coreLives;
    public int lives = 50;

    public static int waves;
    public static int score;

    // Start is called before the first frame update
    void Start()
    {
        money = startMoney;
        coreLives = lives;
        waves = 0;
        score = 0;
    }

    [Header ("UI Text:")]
    public TextMeshProUGUI moneyTMP;
    public TextMeshProUGUI scoreTMP;

    void Update()
    {
        moneyTMP.text = "$:" + PlayerStats.money.ToString();
        scoreTMP.text = "Score:" + PlayerStats.score.ToString();
    }
}
