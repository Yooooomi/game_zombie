using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack_explode : attack_manager
{
    public GameObject explosion_effect;
    private GameObject obj;

    public override bool attack(data_center dc)
    {
        foreach (GameObject ply in db.player_list)
            if (Vector3.Distance(ply.transform.position, transform.position) <= attack_distance)
            {
                dc.st.deal_damages(ref_zombie.damage);
            }
        obj = Instantiate(explosion_effect, transform.position, Quaternion.identity);
        Destroy(obj, 1f);
        Destroy(gameObject, 0.01f);
        return (false);
    }
}
