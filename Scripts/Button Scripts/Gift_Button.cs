using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Gift_Button : MonoBehaviour
{
    public GameObject coinCountUI;
    public static Button dailyGiftButton;
    public Animator dailyGift;
    public TMP_Text coinAmount;

    private int playerBalance;
    private int randomCoinAmount;

    public static bool enable = false;
    public static int count = 0;

    private void Awake()
    {
        dailyGiftButton = GetComponent<Button>();
        coinAmount.text = PlayerPrefs.GetInt("coinCountPref", 0).ToString();
        StartCoroutine(timer.CheckTimeToo());
    }

    public void DailyGift()
    {
        AudioManager.playClick();
        if (count == 0)
        {
            //Logging the times needed.
            PlayerPrefs.SetString("LastGiftTime", timer.UTCTime.ToString());
            PlayerPrefs.SetString("NextGiftTime", timer.UTCTime.AddDays(1).ToString());

            //Debug.Log(timer.UTCTime.ToString());
            //Debug.Log(timer.UTCTime.AddDays(1).ToString());

            //Calculate the coin count and play the animation.
            randomCoinAmount = UnityEngine.Random.Range(60, 101);
            dailyGift.SetTrigger("Start");

            //Add the coins to the players balance.
            playerBalance = PlayerPrefs.GetInt("coinCountPref", 0);
            playerBalance += randomCoinAmount;
            PlayerPrefs.SetInt("coinCountPref", playerBalance);

            //Disable button temporarily and let the coroutine enable it again if need be. The timer will reactivate the button 24 hours after a successful click.
            dailyGiftButton.interactable = false;

            //Correct the display.
            coinAmount.text = PlayerPrefs.GetInt("coinCountPref", 0).ToString();
            count++;
        }
        timer.activateMinuteCheck();
    }
}
