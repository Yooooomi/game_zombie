using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon_taking : obj_taking {

    public weapon wp;

    public override void apply_on_player(data_center dc)
    {
        Debug.Log("PICK UP");
        dc.wp_man.pick_up_weapon(wp);
    }
}
