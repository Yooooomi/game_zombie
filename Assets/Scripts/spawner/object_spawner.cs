using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class object_spawner : MonoBehaviour {

    public float spawn_wait_minimum = 10;
    private float time_last_spawn = 0;
    private float spawn_wait;
    public bool obj_on = false;
    private const float random_influance = 10;
    private data_base_spawner data;
    public int standard_spawn_rate = 60;
    public int rare_spawn_rate = 25;
    public int epic_spawn_rate = 15;
    public bool is_activated = true;

    // Use this for initialization

    private float get_new_spawn_wait ()
    {
        return (spawn_wait_minimum + Random.Range(0f, random_influance));
    }

	void Start () {
        data = GameObject.Find("data_base_spawner").GetComponent<data_base_spawner>();
        spawn_wait = get_new_spawn_wait();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos;

        if (is_activated && !obj_on)
            time_last_spawn += Time.deltaTime;
        if (is_activated && spawn_wait < time_last_spawn && !obj_on)
        {
            GameObject to_instatiate;
            Debug.Log("Spawn");
            pos = transform.position;
            pos.y += 1;
            to_instatiate = data.get_spawn_obj(standard_spawn_rate, rare_spawn_rate, epic_spawn_rate);
            GameObject obj = Instantiate(to_instatiate, pos, Quaternion.identity);
            obj.GetComponent<obj_taking>().spawner = this;
            obj.GetComponent<obj_taking>().owner = this.gameObject;
            obj_on = true;
            spawn_wait = get_new_spawn_wait();
            time_last_spawn = 0;
        }
	}
}
