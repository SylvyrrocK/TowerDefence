using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyMenu : MonoBehaviour
{
    [Header ("Towers:")]
    public TowerStats defaultTower;
    public TowerStats minigunTower;
    public TowerStats mortarTower;
    public TowerStats slowFieldTower;

    TowerBuilding towerBuilding;

    public void SelectDefaultTower()
    {
        Debug.Log("Default Tower Picked");
        towerBuilding.PickTowerToPlace(defaultTower);
    }

    public void SelectMinigun()
    {
        Debug.Log("Minigun Tower Picked");
        towerBuilding.PickTowerToPlace(minigunTower);
    }

    public void SelectMortar()
    {
        Debug.Log("Mortar Tower Picked");
        towerBuilding.PickTowerToPlace(mortarTower);
    }

    public void SelectSlowField()
    {
        Debug.Log("Slow Field Picked");
        towerBuilding.PickTowerToPlace(slowFieldTower);
    }

    private void Start()
    {
        towerBuilding = TowerBuilding.instance;
    }
}
