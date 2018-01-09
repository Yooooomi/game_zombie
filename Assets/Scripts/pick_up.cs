using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pick_up : MonoBehaviour {

    public data_center dc;
    private obj_taking obj_tak;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("ENTER TRIGGER");
        if (other.gameObject.CompareTag("pick_up"))
        {
            obj_tak = other.GetComponent<obj_taking>();
            if (obj_tak.dropped > 1 || obj_tak.owner != this.gameObject)
                other.gameObject.GetComponent<obj_taking>().apply_on_player(dc);
        }
    }
}
