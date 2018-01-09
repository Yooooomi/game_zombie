using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow_player : MonoBehaviour {

    public GameObject to_follow;
    public float smooth = 10;
    public float z_offset = 0;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos_follow = to_follow.transform.position;
        pos_follow.y = transform.position.y;
        pos_follow.z -= z_offset;
        transform.position = Vector3.Lerp(transform.position, pos_follow, smooth * Time.deltaTime);
    }
}
