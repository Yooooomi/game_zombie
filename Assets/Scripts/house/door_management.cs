using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class door_management : MonoBehaviour {

    private float speed_opening = 3f;
    private bool opening = false;
    public Action open_call_fct;
    private float size_x = 0;
    private float total_move_x = 0;

	// Use this for initialization
	void Start () {
        size_x = transform.localScale.x;
	}
	
	// Update is called once per frame
	void Update () {
		if (opening)
        {
            Vector3 mov = new Vector3((Mathf.Cos((float) Math.PI / 4)) - transform.rotation.y, 0, transform.rotation.y / (Mathf.Cos((float)Math.PI / 4)));
            mov.Normalize();
            mov *= speed_opening * Time.deltaTime;
            transform.position += mov;
            total_move_x += Mathf.Abs(mov.x) + Mathf.Abs(mov.z);
            if (size_x < total_move_x)
            {
                Destroy(this.gameObject);
            }
            //Debug.Log(transform.localScale);
            //transform.localScale -= new Vector3(mov.z + mov.x, 0, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            opening = true;
            open_call_fct();
        }
    }
}
