using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class follow_player : MonoBehaviour {

    public GameObject to_follow;
    public float smooth = 10;
    public float z_offset = 0;
    public float height = 10;
    public float mode_force = 5;
    private float ini_pos_y;
    private bool mode = false;
    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 pos_follow = to_follow.transform.position;
        bool change_mode = CrossPlatformInputManager.GetButtonDown("Change_mode");
        Vector3 m_pos = Input.mousePosition;

        if (change_mode)
            mode = !mode;
        if (mode)
        {
            m_pos = cam.ScreenToViewportPoint(m_pos) - new Vector3(0.5f, 0.5f, 0);
            m_pos *= mode_force;
            pos_follow.x += m_pos.x;
            pos_follow.z += m_pos.y;
        }
        pos_follow.y = to_follow.transform.position.y + height;
        pos_follow.z -= z_offset;
        transform.position = Vector3.Lerp(transform.position, pos_follow, smooth * Time.deltaTime);
    }
}
