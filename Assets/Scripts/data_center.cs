using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class data_center : MonoBehaviour
{

    public stats st;
    public Camera cam;
    public weapon_management wp_man;
    public ui_manager ui;
    public movement mov;
    public dot_manager dot;

    public List<perk_obj> func_health = new List<perk_obj>();
    public List<perk_obj> func_health_malus = new List<perk_obj>();
    public List<perk_obj> func_damages = new List<perk_obj>();
    public List<perk_obj> func_damages_malus = new List<perk_obj>();

    private void Awake()
    {
        dot = GetComponent<dot_manager>();
    }
}
