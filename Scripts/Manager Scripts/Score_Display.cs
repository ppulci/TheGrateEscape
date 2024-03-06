using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score_Display : MonoBehaviour
{
    public TMP_Text scoreAmount;

    private void Awake()
    {
        scoreAmount.text = PlayerPrefs.GetInt("highscore", 0).ToString();
    }
}
