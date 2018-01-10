using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class perk_func {

    public Func<float, float> func;
    public int priority;

    public perk_func() {}

    public perk_func(Func<float, float> f, int prio)
    {
        func = f;
        priority = prio;
    }
}
