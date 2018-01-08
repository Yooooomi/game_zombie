﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class object_spawner : MonoBehaviour {

    public float spawn_wait_minimum = 10;
    private float time_last_spawn = 0;
    private float spawn_wait;
    public bool obj_on = false;
    private const float random_influance = 10;
    private data_base_spawner data = GameObject.Find("data_base_spawner").GetComponent<data_base_spawner>();
    // Use this for initialization

    private float get_new_spawn_wait ()
    {
        return (spawn_wait_minimum + Random.Range(0f, random_influance));
    }

	void Start () {
        spawn_wait = get_new_spawn_wait();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos;

        if (!obj_on)
            time_last_spawn += Time.deltaTime;
        if (spawn_wait < time_last_spawn && !obj_on)
        {
            Debug.Log("Spawn");
            pos = transform.position;
            pos.y += 3;
            GameObject obj = Instantiate(data.get_spawn_obj(), pos, Quaternion.identity);
            obj.GetComponent<obj_taking>().spawner = this;
            obj_on = true;
            spawn_wait = get_new_spawn_wait();
            time_last_spawn = 0;
        }
	}
}
