using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;
using System.Linq;

public class movement : MonoBehaviour {

    private data_center dc;
    private CharacterController cc;

	public Camera cam;
	public float rotateSpeed = 0;
    public bool is_interact = false;

    public GameObject wp_obj;

	// Use this for initialization
	void Start () {
        dc = GetComponent<data_center>();
        cc = GetComponent<CharacterController>();
		Debug.Log("Commencé");
	}

	void lookAtMouse()
	{
        RaycastHit[] hits;
		Vector3 mousePos = Input.mousePosition;
		Vector3 tmp = Vector3.zero;
		Ray ray = cam.ScreenPointToRay (mousePos);
        RaycastHit result;
        Quaternion angle;

        hits = Physics.RaycastAll(ray);
        result = hits.First(s => s.collider.gameObject.CompareTag("Ground"));
		tmp = result.point;
		tmp.y = wp_obj.transform.position.y;
		tmp = tmp - wp_obj.transform.position;
        angle = Quaternion.LookRotation(tmp);
        transform.rotation = Quaternion.Lerp(wp_obj.transform.rotation, angle, rotateSpeed * Time.deltaTime);
	}

	// Update is called once per frame
	void Update () {
        float v = CrossPlatformInputManager.GetAxis("Vertical");
        float h = CrossPlatformInputManager.GetAxis("Horizontal");
        Vector3 dir = Vector3.zero;
        bool isSprint = CrossPlatformInputManager.GetButton("Sprint");
        float tmp_move_speed = dc.st.moveSpeed;

        is_interact = CrossPlatformInputManager.GetButtonDown("Interact");
		if (h != 0 || v != 0) {
			dir = new Vector3 (h, 0, v);
            tmp_move_speed = dc.get_real_move_speed(tmp_move_speed);
            dir *= tmp_move_speed / dir.magnitude;
            if (isSprint)
                dir *= dc.st.sprintMultiplier;
            dir *= Time.deltaTime;
		}
        if (!cc.isGrounded)
        {
            dir.y = Physics.gravity.y * Time.deltaTime;
        }
		cc.Move(dir);
		lookAtMouse ();
	}
}
