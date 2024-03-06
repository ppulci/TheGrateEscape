using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetObjectScale : MonoBehaviour
{
    public Transform scalerObject;
    private float screenHeight;
    private float screenWidth;

    void Awake()
    {
        Debug.Log(Screen.height);
        Debug.Log(Screen.width);

        screenHeight = Screen.height;
        screenWidth = Screen.width;

        float screenScaleH = screenHeight / 569;
        float screenScaleW = screenWidth / 320;

        Debug.Log(screenScaleH);
        Debug.Log(screenScaleW);

        scalerObject.transform.localScale = new Vector3(screenScaleW, screenScaleH, 1);
    }

}
