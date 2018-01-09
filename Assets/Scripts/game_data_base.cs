using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_data_base : MonoBehaviour {

    public List<GameObject> player_list;

	// Use this for initialization
	void Start () {
		player_list = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
