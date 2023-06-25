using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMenu : MonoBehaviour
{
    private BaseBlock target;

    public GameObject UI;
    public void SetTarget(BaseBlock _target)
    {
        target = _target;

        transform.position = target.transform.position;
        UI.SetActive(true);
    }

    public void Hide()
    {
        UI.SetActive(false);
    }

    public void SellTower(BaseBlock tower)
    {

    }

    public void UpgradeTower()
    {

    }
}
