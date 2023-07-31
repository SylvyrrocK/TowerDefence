using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TowerMenu : MonoBehaviour
{
    private BaseBlock target;

    public GameObject UI;

    public TextMeshProUGUI upgradePrice;

    public TextMeshProUGUI sellPrice;

    public Button upgradeButton;
    public void SetTarget(BaseBlock _target)
    {
        target = _target;

        if (!target.isUpgraded)
        {
            upgradePrice.text = "Upgrade " + "$" + target.towerStats.upgradePrice;

            sellPrice.text = "Sell " + "$" + target.towerStats.sellPrice;
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeButton.interactable = false;

            upgradePrice.text = "Max Level";

            sellPrice.text = "Sell " + "$" + target.towerStats.sellPrice;
        }

        transform.position = target.transform.position;
        UI.SetActive(true);
    }

    public void Hide()
    {
        UI.SetActive(false);
    }

    //TODO:
    //public void SellTower(BaseBlock tower)
    //{
    //    PlayerStats.money += target.towerStats.sellPrice;
    //    Destroy(tower);
    //    Debug.Log("Sold");
    //}

    public void Upgrade()
    {
        target.UpgradeTurret();
        TowerBuilding.instance.DeselectNode();
    }
}
