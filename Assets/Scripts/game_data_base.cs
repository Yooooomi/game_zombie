using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class game_data_base : MonoBehaviour {

    public List<GameObject> player_list;

    public List<GameObject> zombie_list;
    private float time_spawn_zombie = 3;

	// Use this for initialization
	void Start () {
		player_list = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));
        zombie_list.OrderBy(s => s.GetComponent<zombie_manager>().stats.diffuculty);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public float get_time_spawn_zombie()
    {
        return (time_spawn_zombie);
    }
}
