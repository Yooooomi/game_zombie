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
    public GameObject aim_obj;

    public bool is_accurate = false;

	// Use this for initialization
	void Start () {
        dc = GetComponent<data_center>();
        cc = GetComponent<CharacterController>();
		Debug.Log("Commencé");
	}

    void lookAtMouse()
    {
        Vector3 mouse_pos = Input.mousePosition;
        Vector3 aim_pos = cam.WorldToScreenPoint(aim_obj.transform.position);
        Vector3 v_angle = mouse_pos - aim_pos;
        v_angle = new Vector3(v_angle.x, 0, v_angle.y);
        Quaternion angle = Quaternion.LookRotation(v_angle);

        transform.rotation = Quaternion.Lerp(aim_obj.transform.rotation, angle, rotateSpeed * Time.deltaTime);
        if (is_accurate)
        {
            RaycastHit[] hits;
            RaycastHit result;
            Ray ray = cam.ScreenPointToRay(mouse_pos);

            hits = Physics.RaycastAll(ray);
            hits.OrderBy(s => Vector3.Distance(ray.origin, s.transform.position));
            result = hits.First(s => !s.collider.isTrigger && !s.collider.gameObject.CompareTag("Player") && !s.collider.gameObject.CompareTag("Zombie"));
            wp_obj.transform.LookAt(result.point);
        }
        else
        {
            wp_obj.transform.rotation = transform.rotation;
        }
    }

	// Update is called once per frame
	void Update () {
        float v = CrossPlatformInputManager.GetAxis("Vertical");
        float h = CrossPlatformInputManager.GetAxis("Horizontal");
        bool isSprint = CrossPlatformInputManager.GetButton("Sprint");
        bool change_accuracy = CrossPlatformInputManager.GetButtonDown("Accurate_mode");
        Vector3 dir = Vector3.zero;
        float tmp_move_speed = dc.st.moveSpeed;

        if (change_accuracy)
            is_accurate = !is_accurate;
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
