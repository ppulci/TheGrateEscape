using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheese_Ball : MonoBehaviour
{
    private Rigidbody2D cheeseball;
    private Animator cheeseAni;

    private int direction;

    public void Start()
    {
        //Maybe change this calc to void Awake() is need be.
        cheeseball = GetComponent<Rigidbody2D>();
        cheeseAni = GetComponent<Animator>();
        direction = Random.Range(0, 2);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (direction == 0)
        {
            cheeseAni.SetTrigger("Go");
            cheeseball.AddForce(new Vector2(-100, 0));
        }
        else
        {
            cheeseAni.SetTrigger("GoRight");
            cheeseball.AddForce(new Vector2(100, 0));
        }
    }
}
