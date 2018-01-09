using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour {

    public string Name;
    public int clip_cap;
    public int max_ammo;
    public int clip_ammo;
    public int ammo;
    public float fire_rate;
    public float reload_time;
    public float range;

    public bool can_fire()
    {
        if (clip_ammo > 0)
            return (true);
        else
            return (false);
    }

    public void reload()
    {
        if (clip_ammo == clip_cap || ammo == 0)
            return;
        else if (ammo >= clip_cap - clip_ammo)
        {
            ammo -= clip_cap - clip_ammo;
            clip_ammo = clip_cap;
        } else if (ammo < clip_cap - clip_ammo) {
            clip_ammo += ammo;
            ammo = 0;
        }
    }

}
