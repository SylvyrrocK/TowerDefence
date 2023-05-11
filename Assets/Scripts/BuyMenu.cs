using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyMenu : MonoBehaviour
{
    public TowerStats defaultTower;
    public TowerStats minigunTower;
    public TowerStats mortarTower;
    public TowerStats slowFieldTower;
    //private bool completed = false;
    TowerBuilding towerBuilding;

    public void SelectDefaultTower()
    {
        Debug.Log("Default Tower Picked");
        towerBuilding.PickTowerToPlace(defaultTower);

        //if (!completed)
        //{
        //    Debug.Log("Default Tower Picked");
        //    towerBuilding.PickTowerToPlace(defaultTower);
        //    completed = true;
        //}
        //if (completed)
        //{
        //    return;
        //}
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
