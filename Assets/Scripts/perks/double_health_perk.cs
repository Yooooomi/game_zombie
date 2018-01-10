using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class double_health_perk : perk {

    static public float double_health(float h)
    {
        return (h * 5);
    }

    public override void on_add(data_center dc)
    {
        base.on_add(dc);
        dc.func_health.Add(double_health);
    }

    public override void on_remove(data_center dc)
    {
        base.on_remove(dc);
        dc.func_health.Remove(double_health);
    }

}
