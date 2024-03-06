using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Game-Over variables
    public GameObject gameOverUI;
    public GameObject highscoreUI;
    public Animator gameoverFade;

    public static bool gameOver = false;

    void Update()
    {
        if (gameOver) 
        {
            //Add functionaility to show the score player achieved.
            highscoreUI.SetActive(false);
            gameOverUI.SetActive(true);
            gameoverFade.SetTrigger("EndScreen");
        } 
        else
        {
            gameOverUI.SetActive(false);
            highscoreUI.SetActive(true);
        }
    }
}
