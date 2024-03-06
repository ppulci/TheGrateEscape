using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DAG_PopSound : MonoBehaviour
{
    public AudioClip popSound;
    public AudioSource thisSource;

    public void dagPopSound()
    {
        if (AudioManager.soundEnabled) { thisSource.PlayOneShot(popSound); }
    }
}
