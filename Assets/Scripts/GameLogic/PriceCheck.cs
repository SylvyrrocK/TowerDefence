using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class PriceCheck : MonoBehaviour
{
    // Start is called before the first frame update
    TowerStats towerStats;
    
    public void NotEnoughMoney()
    {
        if (PlayerStats.money < towerStats.towerPrice)
        {
            GetComponent<TextMeshProUGUI>().color = Color.red;
        }
    }

    public void EnoughMoney()
    {
        if (PlayerStats.money >= towerStats.towerPrice)
        {
            GetComponent<TextMeshProUGUI>().color = Color.green;
        }
    }
}
