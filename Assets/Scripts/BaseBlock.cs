using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class BaseBlock : MonoBehaviour
{
    public  GameObject isTurret;
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
        if (!towerBuilding.AbleToBuild)
        {
            return;
        }

        if (towerBuilding.EnoughMoney && isTurret == null)
        {
            // Set green colour
            blockRend.material.color = new Color(0, 1, 0, 1);
        }

        if (!towerBuilding.EnoughMoney || isTurret != null)
        {
            // Set red colour
            blockRend.material.color = new Color(1, 0, 0, 1);
        }
        //else
        //{
        //    // Set red colour
        //    blockRend.material.color = new Color(1, 0, 0, 1);
        //}

        // DELETE LATER
        // Set cyan color on hover
        //blockRend.material.color = new Color(0,1,1,1);
        //blockRend.material = hoverMaterial;
    }

    void OnMouseExit()
    {
        // Set white colour on exit
        blockRend.material.color = new Color(1,1,1,1);
        //blockRend.material = startMaterial;
    }

    void OnMouseDown()
    {
        if (!towerBuilding.AbleToBuild)
        {
            return;
        }

        if (isTurret != null)
        {
            Debug.Log("Cell already taken!"); // TODO: Popup with text ingame 
            return;
        }

        // Call method from Tower Building class for selected node
        towerBuilding.TowerBuild(this);
        blockRend.material.color = new Color(1, 1, 1, 1); // White
    }
}
