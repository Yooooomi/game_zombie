using System.Collections;
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
		Ray r = cam.ScreenPointToRay (mousePos);
		RaycastHit result;
		Vector3 tmpp = Vector3.zero;

		if (Physics.Raycast (r, out result)) {
			tmp = result.point;
			tmp.y = transform.position.y;
			tmpp = tmp - transform.position;
			Quaternion angle = Quaternion.LookRotation (tmpp);
			transform.rotation = Quaternion.Lerp (transform.rotation, angle, rotateSpeed * Time.deltaTime);
		}
	}

	// Update is called once per frame
	void Update () {
		float v = CrossPlatformInputManager.GetAxis ("Vertical");
		float h = CrossPlatformInputManager.GetAxis ("Horizontal");
		Vector3 dir = Vector3.zero;

		if (h != 0 || v != 0) {
			dir = new Vector3 (h, 0, v);
			dir *= st.moveSpeed / dir.magnitude;
			dir *= Time.deltaTime;
		}
		Debug.Log (dir.magnitude);

		gameObject.transform.position += dir;
		lookAtMouse ();
	}
}
