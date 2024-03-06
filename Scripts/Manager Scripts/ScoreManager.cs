using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text highscoreText;

    public static int score = 0;
    public int highscore = 0;

    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = score.ToString() + " Points";
        highscoreText.text = "Highscore: " + highscore.ToString();
    }

    public void LateUpdate()
    {
        //For the Highscore to change, game must be stopped when higher than pervious HS
        scoreText.text = score.ToString() + " Floors";

        if (highscore < score)
        {
            PlayerPrefs.SetInt("highscore", score);

            //Upload score to leaderboard, EVERYUPDATE
            if (LeaderBoards.connectedToGooglePlay)
            {
                Social.ReportScore(highscore, GPGSIds.leaderboard_highscore, LeaderBoards.LeaderBoardUpdated);
            }
        }
    }
}
