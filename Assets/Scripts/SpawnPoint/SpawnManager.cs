using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject PrefabToSpawn;
    public float repeatInterval;
    public bool enableSpawn = false;
    int enemySpawnLimit;
    public GameObject[] enemies;
    public void Start()
    {
        enemySpawnLimit = 40;
        if (repeatInterval > 0)
        {
            InvokeRepeating("SpawnEnemy", 0.0f, repeatInterval);
        }
    }
    public GameObject SpawnEnemy()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length < enemySpawnLimit)
        {
            if (PrefabToSpawn != null)
            {
                return Instantiate(PrefabToSpawn, transform.position, Quaternion.identity);
            }
        }
        return null;
    }
}
