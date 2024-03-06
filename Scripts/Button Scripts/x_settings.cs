using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class x_settings : MonoBehaviour
{
    public GameObject settingsMenu;
    public GameObject infoMenu;

    public static bool loadGame;
    public static bool loadShop;
    public static bool restartGame;
    public static bool mainMenu;

    public void STARTGame()
    {
        AudioManager.playClick();
        loadGame = true;
    }
    public void LOADShop()
    {
        AudioManager.playClick();
        loadShop = true;
    }
    public void OPENSettingsMenu()
    {
        AudioManager.playClick();
        settingsMenu.SetActive(true);
    }
    public void CLOSESettingsMenu()
    {
        AudioManager.playClick();
        settingsMenu.SetActive(false); 
    }
    public void INFOSettingsMenu()
    {
        AudioManager.playClick();
        infoMenu.SetActive(false);
    }
    public void RESTARTGame()
    {
        AudioManager.playClick();
        restartGame = true;
        GameManager.gameOver = false;
        ScoreManager.score = 0;
    }
    public void LOADMenu()
    {
        AudioManager.playClick();
        mainMenu = true;
        GameManager.gameOver = false;
        ScoreManager.score = 0;
    }
}
