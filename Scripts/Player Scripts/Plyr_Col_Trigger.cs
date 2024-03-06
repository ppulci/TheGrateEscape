using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plyr_Col_Trigger : MonoBehaviour
{
    public AudioClip deathSound;
    public AudioSource seanSource;

    public Animator seanMovement;

    private GameObject objectHit;
    private Animator belleTrap;

    //Disabling the collider after death to ensure the game doesnt detect a death during the restart animation.
    private CircleCollider2D disableCircle;
    private BoxCollider2D disableBox;

    //Enemy Collison Detection
    void OnTriggerEnter2D(Collider2D collision)
    {
        objectHit = collision.gameObject;
        CollisionCalc(collision.gameObject);
    }

    void CollisionCalc(GameObject collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            StartCoroutine(Death());
            disableCircle = collider.GetComponent<CircleCollider2D>();
            disableCircle.enabled = false;
        }
        
        if(collider.CompareTag("Belle"))
        {
            StartCoroutine(BelleDeath());
            belleTrap = collider.GetComponent<Animator>();
            belleTrap.SetTrigger("Go");
            disableBox = collider.GetComponent<BoxCollider2D>();
            disableBox.enabled = false;
        }

        if (collider.CompareTag("Coin"))
        {
            CoinManager.coinCountInRun++;
            Destroy(objectHit);
        }

        if (collider.CompareTag("Death Zone"))
        {
            StartCoroutine(Death());
        }
    }

    IEnumerator Death()
    {
        Player_Movement.allowMovement = false;
        seanMovement.SetTrigger("Death");
        if (AudioManager.soundEnabled) { seanSource.PlayOneShot(deathSound); }
        yield return new WaitForSeconds(1);
        GameManager.gameOver = true;
    }
    IEnumerator BelleDeath()
    {
        Player_Movement.allowMovement = false;
        AudioManager.playGulp();
        seanMovement.SetTrigger("Belle Invisible");
        yield return new WaitForSeconds(1);
        GameManager.gameOver = true;
    }
}
