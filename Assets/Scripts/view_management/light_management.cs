using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light_management : MonoBehaviour {

    private game_data_base db;
    private Light l;

	// Use this for initialization
	void Start () {
        db = GameObject.Find("game_data_base").GetComponent<game_data_base>();
        l = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
        l.intensity = ((0.5f - Mathf.Abs(db.get_time_day() - 0.5f)) / 0.5f) * db.max_intens;
	}
}
