using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;

public class timer : MonoBehaviour
{
    public static myTime utcTime;
    public static DateTime UTCTime;
    public Button dailyGiftButton;
    public TMP_Text cooldownText;

    private double secondsCD;
    private TimeSpan cooldownTimer;
    private static float addingTime = 61;
    private string NextGiftTime;
    private DateTime NextGiftTimeDT;

    public class myTime
    {
        public string datetime;
    }

    private void Awake()
    {
        nextGiftTimeCheck();
    }

    private void LateUpdate()
    {
        addingTime += Time.deltaTime;
        if (addingTime > 60)
        {
            //Check the time, if its past the Last Gifted Time enable the button.
            StartCoroutine(CheckTimeToo());
            nextGiftTimeCheck();
            cooldownTimer = NextGiftTimeDT.Subtract(UTCTime);
            secondsCD = Math.Round(cooldownTimer.TotalSeconds);

            //After 60 seconds reset the timer.
            addingTime = 0;
        }
        if (secondsCD < 0)
        {
            Gift_Button.count = 0;
            dailyGiftButton.interactable = true;
            cooldownText.text = null;
        }
        else
        {
            dailyGiftButton.interactable = false;
            secondsCD -= Time.deltaTime;

            //Conversion
            int hours = (int)(secondsCD / 3600) % 24;
            int mins = (int)(secondsCD / 60) % 60;
            int secs = (int)(secondsCD % 60);

            //Reset the timer.
            cooldownText.text = null;
            if (hours > 0) { cooldownText.text += hours + "h "; }
            if (mins > 0) { cooldownText.text += mins + "m "; }
            if (secs > 0) { cooldownText.text += secs + "s "; }
        }
    }

    public static IEnumerator CheckTimeToo()
    {
        var request = UnityWebRequest.Get("http://worldtimeapi.org/api/timezone/etc/UTC/");
        yield return request.SendWebRequest();
        switch (request.result)
        {
            case UnityWebRequest.Result.ConnectionError:
                Debug.Log("Connection Error");
                Gift_Button.dailyGiftButton.interactable = true;
                yield break;
            case UnityWebRequest.Result.DataProcessingError:
                Debug.Log("Data Processing Error");
                Gift_Button.dailyGiftButton.interactable = true;
                yield break;    
            case UnityWebRequest.Result.ProtocolError:
                Debug.Log("Protocol Error");
                Gift_Button.dailyGiftButton.interactable = true;
                yield break;
            case UnityWebRequest.Result.Success:
                var jsonFile = request.downloadHandler.text;
                utcTime = JsonUtility.FromJson<myTime>(jsonFile);
                UTCTime = Convert.ToDateTime(utcTime.datetime);
                break;
        }
    }

    public void nextGiftTimeCheck()
    {
        NextGiftTime = PlayerPrefs.GetString("NextGiftTime", "NONE");
        NextGiftTimeDT = Convert.ToDateTime(NextGiftTime);
    }

    public static void activateMinuteCheck()
    {
        addingTime = 61f;
    }
}