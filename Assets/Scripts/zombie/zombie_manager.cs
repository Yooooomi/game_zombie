using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombie_manager : MonoBehaviour {

    public ParticleSystem particles;
    public zombie_class stats;
	// Use this for initialization
	void Start () {
        stats = new zombie_class();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool deal_damages(int dmg)
    {
        stats.curr_hp -= dmg;
        if (stats.curr_hp < 1 / 2 * stats.max_hp)
            particles.emission.rateOverTime = 
        if (stats.curr_hp <= 0)
        {
            Destroy(this.gameObject);
            return (true);
        }
        return (false);
    }
}
