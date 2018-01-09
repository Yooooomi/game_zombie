using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ui_manager : MonoBehaviour {

    public data_center dc;
    public Text ammo_text;
    public Text weapon_name_text;

    public Text health_text;

    public List<Text> ammo_texts;

    public void refresh_health()
    {
        health_text.text = dc.st.curHealth.ToString();
    }

    public void refresh_weapon()
    {
        weapon cur_wp = dc.wp_man.weapons[dc.wp_man.index];

        weapon_name_text.text = cur_wp.Name;
        ammo_text.text = cur_wp.clip_ammo + " / " + dc.wp_man.ammos[cur_wp.type];
    }

    public void refresh_ammos()
    {
        for (int i = 0; i < ammo_texts.Count; i++)
        {
            ammo_texts[i].text = dc.wp_man.ammos[i].ToString();
        }
    }

}
