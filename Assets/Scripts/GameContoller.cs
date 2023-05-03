using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameContoller : MonoBehaviour
{
    public bool gameOver = false;

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            return;
        }

        if (PlayerStats.coreLives <= 0)
        {
            EndGame();
        }
    }

    void EndGame ()
    {
        gameOver = true;
        Debug.Log("GG");
        Debug.Log(gameOver);
        // TODO: Add end screen UI
    }
}
