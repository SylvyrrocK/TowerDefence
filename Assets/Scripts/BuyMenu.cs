using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyMenu : MonoBehaviour
{
    TowerBuilding towerBuilding;
    public void BuyDefaultTurret()
    {
        Debug.Log("Default Turret Bought");
        towerBuilding.SetTowerToPlace(towerBuilding.defaultTowerPrefab);
    }

    public void BuyMinigunTurret()
    {
        Debug.Log("Minigun Turret Bought");
        towerBuilding.SetTowerToPlace(towerBuilding.minigunTowerPrefab);
    }

    public void BuyMortar()
    {
        Debug.Log("Slow Field Bought");
        towerBuilding.SetTowerToPlace(towerBuilding.mortarTowerPrefab);
    }

    public void BuySlowField()
    {
        Debug.Log("Slow Field Bought");
        towerBuilding.SetTowerToPlace(towerBuilding.slowFieldPrefab);
    }

    private void Start()
    {
        towerBuilding = TowerBuilding.instance;
    }
}
