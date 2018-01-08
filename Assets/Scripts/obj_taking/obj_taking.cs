using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obj_taking : MonoBehaviour {

    public GameObject owner;
    public object_spawner spawner = null;

    public virtual void apply_on_player(data_center dc)
    {
        if (spawner != null)
        {
            spawner.obj_on = false;
        }
    }
}
