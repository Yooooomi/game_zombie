﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class attack_manager : MonoBehaviour {

    private zombie_class ref_zombie;
    private float time_last_attack = 0;
    private GameObject target;
    private List<GameObject> list_player;
    public float attack_distance = 0.5f;
    private float time_update_target = 5f;
    private float time_last_target_update = 0;

    private GameObject get_target()
    {
        float min = list_player.Min(s => Vector3.Distance(s.transform.position, target.transform.position));
        foreach (GameObject ply in list_player)
            if (Vector3.Distance(ply.transform.position, target.transform.position) == min)
                return (ply);
        return (null);
    }
	// Use this for initialization
	void Start () {
        zombie_manager tmp = GetComponent<zombie_manager>();

        list_player = GameObject.Find("game_data_base").GetComponent<game_data_base>().player_list;
        ref_zombie = tmp.stats;
        target = get_target();
	}
	
	// Update is called once per frame
	void Update () {
        time_last_attack += Time.deltaTime;
        time_last_target_update += Time.deltaTime;
		if (time_last_attack < ref_zombie.attack_speed && attack_distance > Vector3.Distance(target.transform.position, transform.position))
        {
            target.GetComponent<stats>().curHealth -= ref_zombie.damage; //deal_damages(ref_zombie.damage);
            time_last_attack = 0;
        }
        if (time_last_target_update < time_update_target)
        {
            target = get_target();
            time_last_target_update = 0;
        }
	}
}