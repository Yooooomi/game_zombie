using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health_tacking : obj_taking {

    private int health_restored = 25;

    public override void apply_on_player(data_center dc)
    {
        base.apply_on_player(dc);
        dc.st.curHealth += health_restored;
        Destroy(this.gameObject);
    }
}
