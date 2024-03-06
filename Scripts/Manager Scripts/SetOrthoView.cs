using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetOrthoView : MonoBehaviour
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
			vcam.m_Lens.OrthographicSize = background.bounds.size.x * Screen.height / Screen.width * 0.5f;
		}

		var thisScript = thisCamera.GetComponent<SetOrthoView>();
		thisScript.enabled = false;
	}
}