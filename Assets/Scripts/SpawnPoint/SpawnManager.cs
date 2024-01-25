using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject PrefabToSpawn;
    public float repeatInterval;

    public void Start()
    {
        if (repeatInterval > 0)
        {
            InvokeRepeating("SpawnEnemy", 0.0f, repeatInterval);
        }
    }
    public GameObject SpawnEnemy()
    {
        if (PrefabToSpawn != null)
        {
            return Instantiate(PrefabToSpawn, transform.position, Quaternion.identity);
        }
        return null;
    }
}
