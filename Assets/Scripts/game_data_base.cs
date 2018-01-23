using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class game_data_base : MonoBehaviour {

    public List<GameObject> player_list;
    public List<GameObject> zombie_list;
    public float time_spawn_zombie = 3f;
    public float time_per_day = 60f;
    public float max_intens = 1f;

    private float actual_time = 30f;

    // Use this for initialization
    void Awake () {
		player_list = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));
        zombie_list.OrderBy(s => s.GetComponent<zombie_manager>().stats.diffuculty);
    }
	
	// Update is called once per frame
	void Update () {
        actual_time += Time.deltaTime;
        if (actual_time >= time_per_day)
            actual_time = 0;
    }

    public float get_time_spawn_zombie()
    {
        return (time_spawn_zombie);
    }

    public float get_time_day() //0 mean midnight
    {
        return (actual_time / time_per_day);
    }
}
