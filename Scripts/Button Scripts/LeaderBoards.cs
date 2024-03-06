using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class LeaderBoards : MonoBehaviour
{
    //Vars
    public static bool connectedToGooglePlay = false;

    //Initialization
    void Awake()
    {
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
    }

    private void Start()
    {
        LogIntoGooglePlay();
    }

    //General Functions
    public static void LeaderBoardUpdated(bool success)
    {
        if (success)
        {
            Debug.Log("Success!");
        } 
        else
        {
            Debug.Log("Error Uploading Score!");
        }
    }

    private void ProcessAuthentication(SignInStatus status)
    {
        if (status == GooglePlayGames.BasicApi.SignInStatus.Success)
        {
            connectedToGooglePlay = true;
        }
        else
        {
            connectedToGooglePlay = false;
        }
    }

    private void LogIntoGooglePlay()
    {
        //Pass in the result to Sign In Status
        PlayGamesPlatform.Instance.Authenticate(ProcessAuthentication);
        Debug.Log("DEBUG: Log In Process Started!");
        Debug.Log(connectedToGooglePlay);
    }

    public void DisplayLeaderboard()
    {
        if (!connectedToGooglePlay)
        {
            LogIntoGooglePlay();
            Debug.Log("Logged in!");
        }
        Social.ShowLeaderboardUI();
        Debug.Log("Working!");
    }
}
