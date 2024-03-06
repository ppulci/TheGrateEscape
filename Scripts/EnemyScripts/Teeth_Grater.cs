using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teeth_Grater : MonoBehaviour
{
    public Transform rightCheck;
    private Vector2 rayDirecton;

    public float speed;
    public int groundrayLength;
    public int rayLength;

    private bool movingRight = true;
    private int direction;


    void Awake()
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
            rayDirecton = Vector2.right;
        }
        else
        {
            movingRight = false;
            rayDirecton = Vector2.left;
        }
    }


    void Update()
    {
        //Speed Calculation w/ Player Sight
        RaycastHit2D PlayerSeer = Physics2D.Raycast(rightCheck.position, rayDirecton, rayLength);
        if (PlayerSeer) { speed = 3.5f; } else { speed = 2f; }

        //Movement Calculation
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(rightCheck.position, Vector2.down, groundrayLength);
            if (groundInfo.collider != true)
            {
                if (movingRight == true)
                {
                    //Move Left
                    transform.eulerAngles = new Vector3(0, -180, 0);
                    movingRight = false;
                    rayDirecton = Vector2.left;
                }
                else
                {
                    //Move Right
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    movingRight = true;
                    rayDirecton = Vector2.right;
                }
            }
        
    }
}
