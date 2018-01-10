using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class perk_stand : MonoBehaviour {

    private data_center dc;
    private perk this_perk;

    private void Start()
    {
        this_perk = GetComponent<perk>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.isTrigger)
            return;
        dc = other.gameObject.GetComponent<data_center>();
        if (dc.mov.is_interact && dc.st.perk_coins > 0)
        {
            Debug.Log("BOUGHT");
            dc.st.remove_coin_perks(1);
            this_perk.add_on(dc);
        }
    }
}
