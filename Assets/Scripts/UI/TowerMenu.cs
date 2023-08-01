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

            upgradeButton.interactable = true;

            sellPrice.text = "Sell " + "$" + target.towerStats.towerPrice / 2;
        }
        else
        {
            upgradeButton.interactable = false;

            upgradePrice.text = "Max Level";

            sellPrice.text = "Sell " + "$" + (target.towerStats.towerPrice + target.towerStats.upgradePrice) / 2;
        }

        transform.position = target.transform.position;
        UI.SetActive(true);
    }

    public void Hide()
    {
        UI.SetActive(false);
    }

    public void Sell()
    {
        target.SellTower();
        target.isUpgraded = false;
        TowerBuilding.instance.DeselectNode();
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        TowerBuilding.instance.DeselectNode();
    }
}
