using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitMenu : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject gameOverMenu;
    private GameManager gm;

    private void Start()
    {
        // Get the GameManager Object and then Get the Script component from the object.
        gameManager = gameObject.GetComponent<GameObject>().GetComponent<GameManager>();
    }

    private void Update()
    {
        if (gameManager.isGameOver())
        {
            gameOverMenu.SetActive(true);
        }
    }

    public void restartGame()
    {
       
        gameOverMenu.SetActive(false);
        gameManager.setGameOver(false);
        SceneManager.LoadScene("SampleScene");
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
