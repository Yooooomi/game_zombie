using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obj_taking : MonoBehaviour {

    public object_spawner spawner;

    public virtual void apply_on_player(data_center dc)
    {
        spawner.obj_on = false;
    }
}
