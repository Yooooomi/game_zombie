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
    public List<int> spawn_rate;
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

        if (!obj_on)
            time_last_spawn += Time.deltaTime;
        if (spawn_wait < time_last_spawn && !obj_on)
        {
            GameObject to_instaciate;
            Debug.Log("Spawn");
            pos = transform.position;
            pos.y += 1;
            if (spawn_rate.Count != 3)
                to_instaciate = data.get_spawn_obj();
            else
                to_instaciate = data.get_spawn_obj(spawn_rate[0], spawn_rate[1], spawn_rate[2]);
            GameObject obj = Instantiate(to_instaciate, pos, Quaternion.identity);
            obj.GetComponent<obj_taking>().spawner = this;
            obj.GetComponent<obj_taking>().owner = this.gameObject;
            obj_on = true;
            spawn_wait = get_new_spawn_wait();
            time_last_spawn = 0;
        }
	}
}
