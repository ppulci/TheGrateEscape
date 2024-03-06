using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TTS_Button : MonoBehaviour
{
    public GameObject TapUI;
    public Rigidbody2D characterRB;

    public void TapToStart()
    {
        TapUI.SetActive(false);
        Player_Movement.allowMovement = true;
        characterRB.constraints = RigidbodyConstraints2D.None;
        characterRB.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
