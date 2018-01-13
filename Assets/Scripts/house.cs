using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class house : MonoBehaviour {

    public GameObject roof;
    int count = 0;

    void check_status()
    {
        if (count == 0)
        {
            roof.SetActive(true);
        }
        if (count > 0)
        {
            roof.SetActive(false);   
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !other.isTrigger)
        {
            count++;
            check_status();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !other.isTrigger)
        {
            count--;
            check_status();
        }
    }
}
