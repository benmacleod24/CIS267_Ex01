using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public GameManager gameManager;

    // Start Time
    private float levelDuration;
    private TMP_Text uiTime;

    // Start is called before the first frame update
    void Start()
    {
        levelDuration = 20;
        uiTime = GetComponent<TMP_Text>();

        gameManager = gameObject.GetComponent<GameObject>().GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        timerTick();
    }

    public void timerTick()
    {
        levelDuration -= Time.deltaTime;
        uiTime.SetText(Math.Ceiling(levelDuration).ToString());

        if (isTimeExipred())
        {
            gameManager.setGameOver(true);
        }
    }

    public bool isTimeExipred()
    {
        if (levelDuration <= 0) return true;
        return false;
    }
}
