﻿using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;

public class movement : MonoBehaviour {

	private stats st;
	public Camera cam;
	public float rotateSpeed = 0;

	// Use this for initialization
	void Start () {
		st = GetComponent<stats> ();
		Debug.Log("Commencé");
	}

	void lookAtMouse()
	{
		Vector3 mousePos = Input.mousePosition;
		Vector3 tmp = Vector3.zero;
		Ray ray = cam.ScreenPointToRay (mousePos);
        RaycastHit result;
        Quaternion angle;

        if (Physics.Raycast (ray, out result)) {
			tmp = result.point;
			tmp.y = transform.position.y;
			tmp = tmp - transform.position;
            angle = Quaternion.LookRotation(tmp);
                transform.rotation = Quaternion.Lerp(transform.rotation, angle, rotateSpeed * Time.deltaTime);
		}
	}

	// Update is called once per frame
	void Update () {
        float v = CrossPlatformInputManager.GetAxis("Vertical");
        float h = CrossPlatformInputManager.GetAxis("Horizontal");
        Vector3 dir = Vector3.zero;
        bool isSprint = CrossPlatformInputManager.GetButton("Sprint");

		if (h != 0 || v != 0) {
			dir = new Vector3 (h, 0, v);
            dir *= st.moveSpeed / dir.magnitude;
            if (isSprint)
                dir *= st.sprintMultiplier;
            dir *= Time.deltaTime;
		}

		gameObject.transform.position += dir;
		lookAtMouse ();
	}
}
