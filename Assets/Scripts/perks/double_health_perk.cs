using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class double_health_perk : perk {

    static public float double_health(float h)
    {
        return (h * 5);
    }

    public override void on_add(data_center dc)
    {
        base.on_add(dc);
        dc.func_health.Add(new perk_obj);
    }

    public override void on_remove(data_center dc)
    {
        base.on_remove(dc);
        dc.func_health.Remove(dc.func_health.First(s => s.Name == p_obj.Name));
    }
}
