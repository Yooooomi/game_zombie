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

    public List<Func<float, float>> func_health = new List<Func<float, float>>();
    public List<Func<float, float>> func_health_malus = new List<Func<float, float>>();
    public List<Func<float, float>> func_damages = new List<Func<float, float>>();
    public List<Func<float, float>> func_damages_malus = new List<Func<float, float>>();

}