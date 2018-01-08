using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class data_base_spawner : MonoBehaviour {
    public List<GameObject> common_obj = new List<GameObject>();
    public List<GameObject> rare_obj = new List<GameObject>();
    public List<GameObject> epic_obj = new List<GameObject>();

    public GameObject get_spawn_obj()
    {
        int rand = Random.Range(0, 100);
        if (rand < 60)
            return (common_obj[Random.Range(0, common_obj.Count - 1)]);
        else if (rand < 85)
            return (rare_obj[Random.Range(0, rare_obj.Count - 1)]);
        else
            return (epic_obj[Random.Range(0, epic_obj.Count - 1)]);
    }
}
