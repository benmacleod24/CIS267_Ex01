using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool gameOver;

    private void Start()
    {
        gameOver = false;
        evalGameState();
    }

    public bool isGameOver()
    {
        return gameOver;
    }

    public void setGameOver(bool gameOver)
    { 
        this.gameOver = gameOver;
        evalGameState();
    }

    public void evalGameState()
    {
        if (gameOver)
        {
            Time.timeScale = 0f;
            return;
        }
        
        Time.timeScale = 1f;
    }
}
