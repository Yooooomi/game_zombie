using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombie_manager : MonoBehaviour {

    public ParticleSystem particles;
    public zombie_class stats;
    // Use this for initialization

    public bool deal_damages(int dmg)
    {
        ParticleSystem.EmissionModule em = particles.emission;
        stats.curr_hp -= dmg;
        if (stats.curr_hp < stats.max_hp)
            em.rateOverTime = 5 + (15 - 15 * (stats.curr_hp / stats.max_hp));
        if (stats.curr_hp <= 0)
        {
            Destroy(this.gameObject);
            return (true);
        }
        return (false);
    }
}
