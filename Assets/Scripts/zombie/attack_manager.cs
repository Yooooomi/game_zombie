using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class attack_manager : MonoBehaviour {

    public game_data_base db;
    public zombie_class ref_zombie;
    private float time_last_attack = 0;
    public GameObject target;
    public float attack_distance = 1.5f;
    private float time_update_target = 5f;
    private float time_last_target_update = 0;

    void Start()
    {
        db = GameObject.Find("Database").GetComponent<game_data_base>();
        zombie_manager tmp = GetComponent<zombie_manager>();

        ref_zombie = tmp.stats;
        target = get_target();
    }

    private GameObject get_target()
    {
        if (db.player_list.Count == 0)
            return (null);
        float min = db.player_list.Min(s => Vector3.Distance(s.transform.position, transform.position));
        foreach (GameObject ply in db.player_list)
            if (Vector3.Distance(ply.transform.position, transform.position) == min)
                return (ply);
        Debug.Log("null target");
        return (null);
    }

    public virtual bool attack(data_center dc)
    {
        dc.st.deal_damages(ref_zombie.damage); //deal_damages(ref_zombie.damage);
        return (false);
    }

	void Update () {
        time_last_attack += Time.deltaTime;
        time_last_target_update += Time.deltaTime;
        if (time_last_target_update > time_update_target)
        {
            target = get_target();
            time_last_target_update = 0;
        }
        if (!target)
            return;
		if (time_last_attack > ref_zombie.attack_speed && Vector3.Distance(target.transform.position, transform.position) < attack_distance)
        {
            attack(target.GetComponent<data_center>());
            time_last_attack = 0;
        }
	}
}
