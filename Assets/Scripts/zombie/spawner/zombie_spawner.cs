using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class zombie_spawner : MonoBehaviour {

    private List<GameObject> zombie_list;
    private Func<float> get_time_spawn;
    private float time_since_last_spawn = 0;
    private int last_difficulty = 1;

	// Use this for initialization
	void Start () {
        game_data_base tmp = GameObject.Find("game_data_base").GetComponent<game_data_base>();
        zombie_list = tmp.zombie_list;
        get_time_spawn = tmp.get_time_spawn_zombie;
	}
	
	// Update is called once per frame
	void Update () {
        time_since_last_spawn += Time.deltaTime;
		if (time_since_last_spawn > get_time_spawn() * last_difficulty)
        {
            Vector3 pos = transform.position;
            GameObject zb;

            pos.y += transform.position.y;
            zb = Instantiate(zombie_list[UnityEngine.Random.Range(0, zombie_list.Count - 1)], pos, Quaternion.identity);
            last_difficulty = zb.GetComponent<zombie_manager>().stats.diffuculty;
            time_since_last_spawn = 0;
        }
	}
}
