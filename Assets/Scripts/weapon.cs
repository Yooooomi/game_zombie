using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour {

    public string Name = "defaut";
    public int clip_cap = 30;
    public int max_ammo = 90;
    public int clip_ammo = 30;
    public int ammo = 90;
    public float fire_rate = 0.1f;
    public float reload_time = 0.5f;
    public float range = 100;

    public weapon()
    {

    }

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
