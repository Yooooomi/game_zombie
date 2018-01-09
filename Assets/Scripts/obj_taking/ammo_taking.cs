using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammo_taking : obj_taking {

    public int type = 0;
    public int amount = 30;

    public override void apply_on_player(data_center dc)
    {
        base.apply_on_player(dc);
        dc.wp_man.add_ammos(type, amount);
        dc.ui.refresh_ammos();
        Destroy(this.gameObject);
    }

}
