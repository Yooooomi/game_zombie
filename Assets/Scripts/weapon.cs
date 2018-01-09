using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class weapon {

    public string Name = "defaut";
    public bool auto = true;
    public int damages = 10;
    public int clip_cap = 30;
    public int clip_ammo = 30;
    public float fire_rate = 7;
    public float reload_time = 0.5f;
    public float range = 100;
    public int type = 0;

    public weapon()
    {

    }

    public float get_fire_rate()
    {
        return (fire_rate / 100);
    }

    public weapon(string name)
    {
        this.Name = name;
    }

    public bool can_fire()
    {
        if (clip_ammo > 0)
            return (true);
        else
            return (false);
    }
}
