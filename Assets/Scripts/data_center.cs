using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class data_center : MonoBehaviour
{
    public stats st;
    public Camera cam;
    public weapon_management wp_man;
    public ui_manager ui;
    public movement mov;
    public dot_manager dot;

    public List<perk_func> func_health = new List<perk_func>();
    public List<perk_func> func_health_malus = new List<perk_func>();
    public List<perk_func> func_damages = new List<perk_func>();
    public List<perk_func> func_damages_malus = new List<perk_func>();
    public List<perk_func> func_speed = new List<perk_func>();
    public List<perk_func> func_speed_malus = new List<perk_func>();

    public void add_func(perk_func func, List<perk_func> tab)
    {
        if (!tab.Any(s => s.nm == func.nm))
        {
            tab.Add(func);
            tab.OrderBy(s => s.priority);
        }
    }

    public float get_real_move_speed(float speed)
    {
        for (int i = 0; i < func_speed.Count; i++)
        {
            speed = func_speed[i].func(speed);
        }
        for (int i = 0; i < func_speed_malus.Count; i++)
        {
            speed = func_speed_malus[i].func(speed);
        }
        return (speed);
    }

    public void remove_func(Func<float, float> func, List<perk_func> tab)
    {
        tab.RemoveAt(tab.FindIndex(s => s.func == func));
    }

    private void Awake()
    {
        dot = GetComponent<dot_manager>();
    }
}
