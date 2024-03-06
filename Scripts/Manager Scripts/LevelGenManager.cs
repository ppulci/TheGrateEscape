using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenManager : MonoBehaviour
{
    //All references used in generation of infinite tiles. (Currently the "Level Objects" is cloned infinitely. This causes the name to be Level_Objects(Clone)(Clone)(Clone) etc.)
    public GameObject gameLevels;
    public GameObject player;
    public GameObject levelGenCheck;
    public GameObject levelGenHeight;
    public GameObject levelGenDelete;

    private Vector3 spawnPoint;
    private float xSpawn = 0;
    private float ySpawn;

    private int spawnCount = 0;

    void Update()
    {
        ySpawn = levelGenHeight.transform.position.y;
        spawnPoint = new Vector3(xSpawn, ySpawn, 0);

        if (Mathf.RoundToInt(player.transform.position.y) == Mathf.RoundToInt(levelGenCheck.transform.position.y) && spawnCount < 1)
        {
            Instantiate(gameLevels, spawnPoint, transform.rotation);
            spawnCount += 1;
            
        } 

        if (Mathf.RoundToInt(player.transform.position.y) == Mathf.RoundToInt(levelGenDelete.transform.position.y) && spawnCount >= 1)
        {
            GameObject.Destroy(gameLevels, 0f);
        }

        //if (TWO PLATFORMS ARE ____ APART, SPAWN ONE INBETWEEN THEM) 
        //{ }
    }
}
