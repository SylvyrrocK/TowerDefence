using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilding : MonoBehaviour
{
    public static TowerBuilding instance;
    private TowerStats selectedTower;

    [Header ("Tower Prefabs:")]
    public GameObject defaultTowerPrefab;
    public GameObject minigunTowerPrefab;
    public GameObject mortarTowerPrefab;
    public GameObject slowFieldPrefab;

    // When script is called we store this tower manager script so we can access it at any point
    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Already loaded TowerBuilding script");
            return;
        }
        instance = this;
    }

    // Property that returns selected tower
    public bool AbleToBuild { get { return selectedTower != null; } }

    // Start is called before the first frame update
    //void Start()
    //{
    //    selectedTower = defaultTowerPrefab;
    //}

    public void PickTowerToPlace(TowerStats tower)
    {
        selectedTower = tower;
    }

    public void TowerBuild(BaseBlock baseBlock)
    {
        if (PlayerStats.money < selectedTower.towerPrice)
        {
            Debug.Log("Your money: " + PlayerStats.money + " Tower price: " + selectedTower.towerPrice);
            return;
        }

        GameObject tower = (GameObject)Instantiate(selectedTower.prefab, baseBlock.transform.position, baseBlock.transform.rotation);
        baseBlock.isTurret = tower;
        PlayerStats.money -= selectedTower.towerPrice;
        Debug.Log("Tower bought: " + PlayerStats.money);
    }
}
