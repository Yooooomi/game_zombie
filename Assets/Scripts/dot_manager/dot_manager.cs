﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class dot_manager : MonoBehaviour {

    private List<Action<data_center>> list_dot_fct = new List<Action<data_center>>();
    private data_center dc;
    private Dictionary<string, Coroutine> dots = new Dictionary<string, Coroutine>();

    void Start()
    {
        dc = GetComponent<data_center>();
    }

    IEnumerator fct_cooldown(Action<data_center> fct, float time)
    {
        yield return new WaitForSeconds(time);
        list_dot_fct.Remove(fct);
    }

    IEnumerator perk_cooldown(perk_func func, List<perk_func> tab, float time)
    {
        yield return new WaitForSeconds(time);
        dc.remove_func(func.func, tab);
    }

    public void add_dot_perk(Func<float, float> func, int prio, float time, string type, string id)
    {
        List<perk_func> funcc;

        switch (type) {
            case "h":
                funcc = dc.func_health;
                break;
            case "hm":
                funcc = dc.func_health_malus;
                break;
            case "d":
                funcc = dc.func_damages;
                break;
            case "dm":
                funcc = dc.func_damages_malus;
                break;
            case "ms":
                funcc = dc.func_speed;
                break;
            case "msm":
                funcc = dc.func_speed_malus;
                break;
            default:
                return;
        }
        perk_func f = new perk_func(id, func, 1);
        dc.add_func(f, funcc);
        if (time > 0)
        {
            if (dots.ContainsKey(f.nm))
            {
                Coroutine to_stop = null;
                if (dots.TryGetValue(f.nm, out to_stop))
                {
                    StopCoroutine(to_stop);
                    dots[f.nm] = StartCoroutine(perk_cooldown(f, funcc, time));
                }
            }
            else
            {
                dots.Add(f.nm, StartCoroutine(perk_cooldown(f, funcc, time)));
            }
        }
    }

    public void add_dot(Action<data_center> fct, float time)
    {
        list_dot_fct.Add(fct);
        if (time > 0)
            StartCoroutine(fct_cooldown(fct, time));
    }

    public void call_dot(data_center dc)
    {
        for (int i = 0; i < list_dot_fct.Count; i++)
        {
            list_dot_fct[i](dc);
        }
    }
}
