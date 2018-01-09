using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ui_manager : MonoBehaviour {

    public data_center dc;
    public Text ammo_text;
    public Text weapon_name_text;

    private void Start()
    {
        refresh_weapon();
    }

    public void refresh_weapon()
    {
        weapon cur_wp = dc.wp_man.weapons[dc.wp_man.index];

        weapon_name_text.text = cur_wp.Name;
        ammo_text.text = cur_wp.clip_ammo + " / " + cur_wp.ammo;
    }
}
