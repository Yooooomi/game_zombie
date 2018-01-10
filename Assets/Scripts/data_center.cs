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

    public void add_func(perk_func func, List<perk_func> tab)
    {
        tab.Add(func);
        tab.OrderBy(s => s.priority);
    }

    public void remove_func(Func<float, float> func, List<perk_func> tab)
    {
        tab.RemoveAt(tab.FindIndex(s => s.func == func));
    }

    private void Awake()
    {
        dot = GetComponent<dot_manager>();
    }

    void Update()
    {
        
    }
}
