using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pick_up : MonoBehaviour {

    public data_center dc;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("ENTER TRIGGER");
        if (other.gameObject.CompareTag("pick_up"))
        {
            other.gameObject.GetComponent<obj_taking>().apply_on_player(dc);
        }
    }
}
