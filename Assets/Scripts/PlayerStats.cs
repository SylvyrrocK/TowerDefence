using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    [Header("Player starting stats")]
    public static int money;
    public int startMoney = 800;

    public static int coreLives;
    public int lives = 50;

    TowerStats towerStats;
    PriceCheck priceCheck;

    // Start is called before the first frame update
    void Start()
    {
        money = startMoney;
        coreLives = lives;
    }

    [Header ("UI Text")]
    public TextMeshProUGUI moneyTMP;

    void Update()
    {
        moneyTMP.text = "$:" + PlayerStats.money.ToString();

        // TODO: When not enough money change price colour to red
        //if (towerStats.towerPrice != null && money < towerStats.towerPrice)
        //{
        //    priceCheck.NotEnoughMone2y();
        //}
        //else
        //{
        //    priceCheck.EnoughMoney();
        //}

    }
}
