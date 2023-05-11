using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LivesScript : MonoBehaviour
{
    public TextMeshProUGUI coreLivesText;

    // Update is called once per frame
    void Update()
    {
        coreLivesText.text = "HP:" + PlayerStats.coreLives.ToString();
    }
}
