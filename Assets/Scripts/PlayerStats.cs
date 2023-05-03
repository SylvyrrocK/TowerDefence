using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int money;
    public int startMoney = 800;

    public static int coreLives;
    public int lives = 50;

    // Start is called before the first frame update
    void Start()
    {
        money = startMoney;
        coreLives = lives;
    }
}
