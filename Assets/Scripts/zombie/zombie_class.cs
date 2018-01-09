using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class zombie_class {
    public float max_hp;
    public float curr_hp;
    public float speed;
    public float damage;
    public float attack_speed;
    public int diffuculty;

    public zombie_class()
    {
        diffuculty = 1;
        max_hp = 100;
        curr_hp = 100;
        speed = 3;
        damage = 10;
        attack_speed = 0.5f;
    }

    public bool is_alive()
    {
        if (curr_hp <= 0)
            return (true);
        else
            return (false);
    }
}
