using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class BaseBlock : MonoBehaviour
{
    public  GameObject isTurret;

    public TowerStats towerStats;

    public bool isUpgraded = false;


    private Renderer blockRend;

    TowerBuilding towerBuilding;

    private void Start()
    {
        blockRend = GetComponent<Renderer>();
        towerBuilding = TowerBuilding.instance;
    }

    void OnMouseEnter()
    {
        // Prevent block hover animation when mouse is over UI element
        if (IsMouseOverUI())
        {
            return;
        }

        // Prevent base block highlight if there is no tower to build selected
        if (!towerBuilding.AbleToBuild)
        {
            return;
        }

        if (towerBuilding.EnoughMoney && isTurret == null)
        {
            //TODO: Add transparent tower preview
            // Set green colour
            blockRend.material.color = new Color(0, 1, 0, 1);
        }

        if (!towerBuilding.EnoughMoney || isTurret != null)
        {
            // Set red colour
            blockRend.material.color = new Color(1, 0, 0, 1);
        }
    }

    void OnMouseExit()
    {
        // Set white colour on exit
        blockRend.material.color = new Color(1,1,1,1);
    }

    void OnMouseDown()
    {
        if (IsMouseOverUI())
        {
            Debug.Log("Clicked on the UI");
            return;
        }

        if (isTurret != null)
        {
            towerBuilding.SelectNode(this);
        }

        if (!towerBuilding.AbleToBuild)
        {
            return;
        }

        // Call method from Tower Building class for selected node
        BuildTurret(towerBuilding.GetTurretToBuild());

        //towerBuilding.TowerBuild(this);
        blockRend.material.color = new Color(1, 1, 1, 1); // White
    }

    void BuildTurret (TowerStats blueprint)
    {
        if (PlayerStats.money < blueprint.towerPrice)
        {
            Debug.Log("Your money: " + PlayerStats.money + " Tower price: " + blueprint.towerPrice);
            return;
        }

        PlayerStats.money -= blueprint.towerPrice;

        GameObject _tower = (GameObject)Instantiate(blueprint.prefab, transform.position, transform.rotation);
        isTurret = _tower;

        towerStats = blueprint;

        GameObject construction = (GameObject)Instantiate(towerBuilding.constructionEffect, transform.position, transform.rotation);
        Destroy(construction, 4f);
       
        towerBuilding.DeselectTower();

        Debug.Log("Tower bought: " + PlayerStats.money);
    }

    public void UpgradeTurret()
    {
        if (isUpgraded)
        {
            return;
        }

        if (PlayerStats.money < towerStats.upgradePrice)
        {
            Debug.Log("Your money: " + PlayerStats.money + " Upgrade price: " + towerStats.upgradePrice);
            return;
        }

        PlayerStats.money -= towerStats.upgradePrice;

        //Remove old turret
        Destroy(isTurret);

        //Build upgraded turret
        GameObject _tower = (GameObject)Instantiate(towerStats.upgradedPrefab, transform.position, transform.rotation);
        isTurret = _tower;

        GameObject construction = (GameObject)Instantiate(towerBuilding.constructionEffect, transform.position, transform.rotation);
        Destroy(construction, 4f);

        isUpgraded = true;
        towerBuilding.DeselectTower();


        Debug.Log("Tower upgraded: " + PlayerStats.money);
    }

    public void SellTower()
    {
        if (isTurret == isUpgraded)
        {
            PlayerStats.money += (towerStats.towerPrice + towerStats.upgradePrice) / 2;
            Debug.Log("1");
        }
        else
        {
            PlayerStats.money += towerStats.sellPrice;
            Debug.Log("2");
        }

        GameObject construction = (GameObject)Instantiate(towerBuilding.sellEffect, transform.position, transform.rotation);
        Destroy(construction, 4f);

        Destroy(isTurret);
        Debug.Log("Tower sold");
    }

    private bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
}
