using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemiesToSpawn;
    public GameObject[] spawnLocations;

    // Start is called before the first frame update
    void Start()
    {
        spawnEnemies(); 
    }

    public void spawnEnemies()
    {
        int randomIndex;
        GameObject enemy;

        for (int i = 0; i < spawnLocations.Length; ++i) 
        {
            randomIndex = Random.Range(0, enemiesToSpawn.Length);
            enemy = Instantiate(enemiesToSpawn[randomIndex].gameObject);
            enemy.transform.position = spawnLocations[i].transform.position;
        }
    }
}
