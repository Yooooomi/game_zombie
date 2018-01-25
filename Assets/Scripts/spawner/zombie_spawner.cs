using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class zombie_spawner : Photon.MonoBehaviour {

    public bool is_active = true;
    public float min_distance_spawn = 40;
    private List<GameObject> zombie_list;
    private game_data_base g_db;
    private Func<float> get_time_spawn;
    private float time_since_last_spawn = 0;
    private int last_difficulty = 1;

	// Use this for initialization
	void Start () {
        g_db = GameObject.Find("Database").GetComponent<game_data_base>();
        zombie_list = g_db.zombie_list;
        get_time_spawn = g_db.get_time_spawn_zombie;
	}

    // Update is called once per frame

    private bool is_player_around()
    {
        foreach (GameObject player in g_db.player_list)
            if (Vector3.Distance(player.transform.position, transform.position) < min_distance_spawn)
                return (true);
        return (false);
    }

    void Update () {
        time_since_last_spawn += Time.deltaTime;
		if (is_active && time_since_last_spawn > get_time_spawn() * last_difficulty && is_player_around())
        {
            time_since_last_spawn = 0;
            if (!PhotonNetwork.isMasterClient)
                return;
            GameObject zb = PhotonNetwork.InstantiateSceneObject(zombie_list[UnityEngine.Random.Range(0, zombie_list.Count)].name, transform.position + transform.up, Quaternion.identity, 0, null);
            last_difficulty = zb.GetComponent<zombie_manager>().stats.diffuculty;
        }
	}
}
