using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class dot_manager : MonoBehaviour {

    private List<Action<data_center>> list_dot_fct = new List<Action<data_center>>();

    IEnumerator fct_cooldown(Action<data_center> fct, float time)
    {
        yield return new WaitForSeconds(time);
        list_dot_fct.Remove(fct);
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
