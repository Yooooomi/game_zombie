using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack_slow : attack_manager {

    public float slow_perc = 30;
    public float duration = 1;

    private float slow(float speed)
    {
        if (speed == 100)
            return (0);
        return (speed / 100 * (100 - slow_perc));
    }

    public override bool attack(data_center dc)
    {
        bool ret = base.attack(dc);
        dc.dot.add_dot_perk(slow, 1, duration, "msm", "zombie_slow");
        return (ret);
    }
}
