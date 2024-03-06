using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    //Player Coin Count
    public static int coinCount;

    //Controlled in player collider script
    public static int coinCountInRun = 0;

    private void Start()
    {
        coinCount = PlayerPrefs.GetInt("coinCountPref", 0);
    }

    private void LateUpdate()
    {
        //Set the coins gained to the players inventory
        if (GameManager.gameOver == true)
        {
            coinCount += coinCountInRun;
            coinCountInRun = 0;
            PlayerPrefs.SetInt("coinCountPref", coinCount);
        }
    }
}
