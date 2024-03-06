using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFullView: MonoBehaviour
{
    public SpriteRenderer background;
    public GameObject thisCamera;

    void LateUpdate()
    {
        var camera = Camera.main;
        var brain = (camera == null) ? null : camera.GetComponent<CinemachineBrain>();
        var vcam = (brain == null) ? null : brain.ActiveVirtualCamera as CinemachineVirtualCamera;

        if (vcam != null)
        {
            float screenRatio = (float)Screen.width / (float)Screen.height;
            float targetRatio = background.bounds.size.x / background.bounds.size.y;

            if (screenRatio >= targetRatio)
            {
                vcam.m_Lens.OrthographicSize = background.bounds.size.y / 2;
            }
            else
            {
                float differenceInSize = targetRatio / screenRatio;
                vcam.m_Lens.OrthographicSize = background.bounds.size.y / 2 * differenceInSize;
            }
        }

        var thisScript = thisCamera.GetComponent<SetFullView>();
        thisScript.enabled = false;
    }
}
