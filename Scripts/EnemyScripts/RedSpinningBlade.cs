using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedSpinningBlade : MonoBehaviour
{
    public Transform rightCheck;

    public float speed;
    public float rayLength;

    private bool movingRight;
    private int direction;
    private float randoSpeed;

    private void Awake()
    {
        //Direction Controller
        direction = Random.Range(0, 2);
        if (direction == 1)
        {
            direction = -180;
        }

        transform.eulerAngles = new Vector3(0, direction, 0);

        if (direction == 0) 
        {
            movingRight = true;
        } else
        {
            movingRight = false;
        }
    }

    void Update()
    {
        //Calculate Scaling Speed & Maximum Speed
        randoSpeed = speed + (ScoreManager.score * 0.05f);
        if (randoSpeed > 5)
        {
            randoSpeed = 5;
        }

        //Movement Calculation
        transform.Translate(Vector2.right * randoSpeed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(rightCheck.position, Vector2.down, rayLength);
        if (groundInfo.collider != true)
        {
            if (movingRight == true)
            {
                //Move Left
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                //Move Right
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }
}
