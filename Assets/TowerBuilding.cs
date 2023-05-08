using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilding : MonoBehaviour
{
    public static TowerBuilding instance;
    private GameObject selectedTower;
    public GameObject defaultTowerPrefab;

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

    public GameObject GetSelectedTower()
    {
        return selectedTower;
    }

    // Start is called before the first frame update
    void Start()
    {
        selectedTower = defaultTowerPrefab;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
