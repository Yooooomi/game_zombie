using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class perk_obj {
    public string Name;
    public int priority;
    public float time;
    public Func<float, float> function;

    public perk_obj()
    {

    }

    public perk_obj(string name, int p, Func<float, float> func, float t)
    {
        Name = name;
        priority = p;
        function = func;
        time = t;
    }
}
