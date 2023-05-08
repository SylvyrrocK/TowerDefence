using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class BaseBlock : MonoBehaviour
{
    private GameObject isTurret;
    //public Material hoverMaterial;
    //[SerializeField] private Material startMaterial;
    private Renderer blockRend;
    TowerBuilding towerBuilding;

    private void Start()
    {
        blockRend = GetComponent<Renderer>();
        towerBuilding = TowerBuilding.instance;
        //startMaterial = blockRend.material;
    }

    // Called once when entering mouse entering BaseBlock object, maybe better to use OnMouseOver ?
    void OnMouseEnter()
    {
        // Prevent block hover animation when mouse is over UI element
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        // Prevent base block highlight if there is no tower to build selected
        if (towerBuilding.GetSelectedTower() == null)
        {
            return;
        }

        // Set cyan color on hover
        blockRend.material.color = new Color(0,1,1,1);
        //blockRend.material = hoverMaterial;
    }

    void OnMouseExit()
    {
        // Set color white color on exit
        blockRend.material.color = new Color(1,1,1,1);
        //blockRend.material = startMaterial;
    }

    void OnMouseDown()
    {
        if (towerBuilding.GetSelectedTower() == null)
        {
            return;
        }

        if (isTurret != null)
        {
            Debug.Log("Cell already taken!"); // TODO: Popup with text ingame 
            return;
        }

        GameObject selectedTurret = towerBuilding.GetSelectedTower();
        isTurret = (GameObject)Instantiate(selectedTurret, transform.position, transform.rotation);
    }
}
