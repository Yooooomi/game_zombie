using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class perk_func {

    public Func<float, float> func;
    public int priority;
    public string nm;

    public perk_func() {}

    public perk_func(string ID, Func<float, float> f, int prio)
    {
        nm = ID;
        func = f;
        priority = prio;
    }
}
