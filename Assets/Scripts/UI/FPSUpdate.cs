using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class FPSUpdate : MonoBehaviour
{
    float fps;
    float updateTimer = 0.2f;
    [SerializeField] private TextMeshProUGUI fpsText;
    [SerializeField] public static bool isDisplayed = true;

    // Update is called once per frame
    private void UpdateFPSDisplay()
    {
        updateTimer -= Time.unscaledDeltaTime;
        if(updateTimer <= 0f)
        {
            fps = 1f / Time.unscaledDeltaTime;
            fpsText.text = "" + Mathf.Round(fps);
            updateTimer = 0.2f;
        }
    }

    public void ToggleFPSDisplay() 
    {
        if(isDisplayed)
        { 
            fpsText.enabled = false;
            isDisplayed = false;
        }
        else
        {
            fpsText.enabled = true;
            isDisplayed = true;
        }
    }

    void Update()
    {
        UpdateFPSDisplay();
    }

    void Start()
    {
        if (isDisplayed)
        {
            fpsText.enabled = true;
        }
        else
        {
            fpsText.enabled = false;
        }
    }
}
