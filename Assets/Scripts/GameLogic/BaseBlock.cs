using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class BaseBlock : MonoBehaviour
{
    public  GameObject isTurret;
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
        towerBuilding.TowerBuild(this);
        blockRend.material.color = new Color(1, 1, 1, 1); // White
    }

    private bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
}
