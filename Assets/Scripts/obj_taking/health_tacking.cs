﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health_tacking : obj_taking {

    public int health_restored = 25;

    public override void apply_on_player(data_center dc)
    {
        base.apply_on_player(dc);
        dc.st.add_health(health_restored);
        Destroy(this.gameObject);
    }
}
