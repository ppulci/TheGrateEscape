using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Transform thisSpawner;
    private GameObject enemySpawned;

    private Vector3 spawnPoint;
    private float xSpawn;
    private float ySpawn;

    void Awake()
    {
            enemySpawned = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
            //Add functionality where the Belle trap can only spawn between (-1f,1f)
            xSpawn = Random.Range(-2f, 2f);
            ySpawn = thisSpawner.transform.position.y + enemySpawned.transform.position.y;
            spawnPoint = new Vector3(xSpawn, ySpawn, 0);

            //Spawn Enemy
            Instantiate(enemySpawned, spawnPoint, transform.rotation);
    }
        
}
