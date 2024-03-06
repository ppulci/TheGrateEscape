using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop_Trap : MonoBehaviour
{
    public Transform thisTrap;
    public GameObject cheeseBall;

    public AudioClip popSound;
    public AudioSource thisSource;

    public Animator trapAnimator;

    private Vector3 spawnPoint;
    private float xSpawn;
    private float ySpawn;

    private bool activateTrap = true;

    public void Awake()
    {
        xSpawn = thisTrap.transform.position.x;
        ySpawn = thisTrap.transform.position.y;
        spawnPoint = new Vector3(xSpawn, ySpawn, 0);
    }

    public void Update()
    {
        if (activateTrap)
        {
            StartCoroutine(BallDropTrap());
            activateTrap = false;
        }
    }

    private void SpawnCheeseBall()
    {
        //Spawn Cheeseball at the Location
        Instantiate(cheeseBall, spawnPoint, transform.rotation);
    }

    IEnumerator BallDropTrap()
    {
        yield return new WaitForSeconds(3);
        trapAnimator.SetTrigger("Start");

        //LET THE TRAP BE FILLED FOR A BIT
        yield return new WaitForSeconds(3);

        //Spawn the cheeseball at the specified location.
        SpawnCheeseBall();

        //Make sure sound effects are enabled!
        if (AudioManager.soundEnabled) { thisSource.PlayOneShot(popSound); }

        trapAnimator.SetTrigger("Restart");

        //Allow the trap to activate.
        activateTrap = true;
    }
}
