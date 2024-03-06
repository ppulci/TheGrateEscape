using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_CollisionDetection : MonoBehaviour
{
    //Platform Variables
    public Collider2D playerCollider;
    public Transform platformCheck;

    public float platformRayLength;

    //Highscore Variables
    public Transform highscoreCheck;

    public float highscoreRayLength;

    private float yPosStorage;
    private float yPosStorageTemp;


    void Awake()
    {
        playerCollider.GetComponent<PolygonCollider2D>();
    }

    void Update()
    {
        //Platform Collision Detection
        RaycastHit2D headCollisionCheck = Physics2D.Raycast(platformCheck.position, Vector2.down, platformRayLength);
        if (headCollisionCheck == true)
        {
            //May hit top platform if detecting collider of enemy while jumping (EDIT: MAY NOT HAPPEN ANYMORE?)
            playerCollider.enabled = true;
        }
        else
        {
            playerCollider.enabled = false;
        }



        //Score Unique Platform Collosion
        RaycastHit2D highscoreCheckRay = Physics2D.Raycast(highscoreCheck.position, Vector2.down, highscoreRayLength);
        if (highscoreCheckRay.point != null)
        {
            yPosStorage = highscoreCheckRay.point.y;

            if (yPosStorage > yPosStorageTemp)
            {
                //Add Score Point
                ScoreManager.score++;

            }
            yPosStorageTemp = highscoreCheckRay.point.y;
            yPosStorageTemp += 2f;
        }
    }
}
