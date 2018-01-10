using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class perk : MonoBehaviour {

    public perk_obj p_obj;

    public static add_virtual_perk(data_center dc, perk_obj obj)
    {
        perk p = new perk();
        p.p_obj = obj;
        p.on_add();
    }

    IEnumerator remove_after(data_center dc)
    {
        yield return new WaitForSeconds(p_obj.time);
        on_remove(dc);
    }

    public virtual void on_add(data_center dc)
    {
        if (p_obj.time != 0)
        {
            StartCoroutine(remove_after(dc));
        }
    }

    public virtual void on_remove(data_center dc)
    {

    }
}
