using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool gameOver;
    public GameObject player;
    private PlayerScore ps;

    private void Start()
    {
        gameOver = false;
        evalGameState();
        Debug.Log(SaveData.loadScore());
        ps = player.GetComponent<PlayerScore>();
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
            SaveData.saveScore(ps.getScore());
            Debug.Log(ps.getScore());
            Time.timeScale = 0f;
            return;
        }
        
        Time.timeScale = 1f;
    }
}
