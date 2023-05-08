using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBlock : MonoBehaviour
{
    private GameObject isTurret;
    //public Material hoverMaterial;
    //[SerializeField] private Material startMaterial;
    private Renderer blockRend;

    private void Start()
    {
        blockRend = GetComponent<Renderer>();
        //startMaterial = blockRend.material;
    }

    // Called once when entering mouse entering BaseBlock object, maybe better to use OnMouseOver ?
    void OnMouseEnter()
    {
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
        if (isTurret != null)
        {
            Debug.Log("Cell already taken!"); // TODO: Popup with text ingame 
            return;
        }

        GameObject selectedTurret = TowerBuilding.instance.GetSelectedTower();
        isTurret = (GameObject)Instantiate(selectedTurret, transform.position, transform.rotation);
    }
}
