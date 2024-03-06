using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    //Transition Variables
    public Animator loadingSlide;

    //Check the animation duration for transition time, usually its 1s
    public float transitionTime = 1f;

    //If the app is restarted, then the tutorial will show again because it is not saved as a player pref
    public static bool tutorialActive = true;

    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex.Equals(3)) 
        {
            StartCoroutine(TutorialScene());
        }
    }

    void Update()
    {
        if (x_settings.loadGame && tutorialActive)
        {
            StartCoroutine(LoadingScene(3));
            x_settings.loadGame = false;
            tutorialActive = false;
        }
        else if (x_settings.loadGame)
        {
            StartCoroutine(LoadingScene(1));
            x_settings.loadGame = false;
        }

        if (x_settings.restartGame)
        {
            StartCoroutine(LoadingScene(1));
            x_settings.restartGame = false;
        }

        if (x_settings.loadShop)
        {
            StartCoroutine(LoadingScene(2));
            x_settings.loadShop = false;
        }

        if (x_settings.mainMenu)
        {
            StartCoroutine(LoadingScene(0));
            x_settings.mainMenu = false;
        }
    }

    //Coroutines
    IEnumerator LoadingScene(int sceneNumber)
    {
        loadingSlide.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneNumber);
        yield return new WaitForSeconds(transitionTime);
    }

    IEnumerator TutorialScene()
    {
        //After a couple seconds auto swap to infinite climb scene
        yield return new WaitForSeconds(4);
        StartCoroutine(LoadingScene(1));
    }
}
