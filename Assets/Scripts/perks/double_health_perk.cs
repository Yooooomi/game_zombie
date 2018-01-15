using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class double_health_perk : perk {

    static public float double_health(float h)
    {
        return (h * 5);
    }

    public override void add_on(data_center dc)
    {
        base.add_on(dc);
        dc.func_health.Add(new perk_func("perk_double_health", double_health, 1));
    }

    public override void remove_on(data_center dc)
    {
        base.remove_on(dc);
        dc.remove_func(double_health, dc.func_health);
    }
}
