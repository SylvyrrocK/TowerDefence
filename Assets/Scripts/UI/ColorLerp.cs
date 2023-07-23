using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ColorLerp : MonoBehaviour
{
    [Header ("Targets: ")]
    [SerializeField] TextMeshProUGUI gameTitle;
    [SerializeField] TextMeshProUGUI playButton;

    [SerializeField] [Range(0f, 1f)] float lerpSpeed;
    int colorIndex = 0;
    float t = 0f;

    [Header ("Title: ")]
    [SerializeField] Color titleStartColor = new Color(1,1,1,1);
    [SerializeField] Color[] colors = new Color[3];

    [Header("Button: ")]
    [SerializeField] Color buttonTargetColor;
    Color currentButtonColor;
    Color buttonStartColor;
    
    void Start()
    {
        buttonStartColor = playButton.color;
    }

    void Update()
    {
        TitleColorChange();
        //PlayColorChange();
    }

    public void TitleColorChange()
    {
        titleStartColor = Color.Lerp(titleStartColor, colors[colorIndex], lerpSpeed*Time.deltaTime);
        gameTitle.color = titleStartColor;

        t = Mathf.Lerp(t, 1f, lerpSpeed * Time.deltaTime);
        if (t > 0.9f)
        {
            t = 0f;
            colorIndex++;
            if (colorIndex >= colors.Length)
            {
                colorIndex = 0;
            }

            //Same as previous if statement
            //colorIndex = (colorIndex >= colors.Length) ? 0 : colorIndex; 
        }
        //Debug.Log("Title button color: " + titleStartColor);
    }

    public void PlayColorChange()
    {
        currentButtonColor = Color.Lerp(buttonStartColor, buttonTargetColor, Mathf.PingPong(Time.time, 1f));
        playButton.color = currentButtonColor;
        //Debug.Log("Play button color: " + currentButtonColor);
    }
}
