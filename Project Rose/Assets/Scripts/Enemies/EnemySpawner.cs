using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{   
    [SerializeField]
    GameObject enemyPrefab;

    void Start()
    {
        InvokeRepeating("Spawn",2.0f, 2.0f);
    }

    void Spawn()
    {
        foreach(Transform spawnPoint in transform)
        {
            Instantiate(enemyPrefab, spawnPoint.transform.position, Quaternion.identity);
        }
    }
}
