using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class data_center : MonoBehaviour {

    public stats st;
    public Camera cam;
    public weapon_management wp_man;
    public ui_manager ui;
    public dot_manager dot;

    private void Awake()
    {
        dot = GetComponent<dot_manager>();
    }
}
