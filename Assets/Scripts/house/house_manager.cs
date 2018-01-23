using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class house_manager : MonoBehaviour {

    //roof rendering mode must be on "fade"

    public List<GameObject> roof;
    public float fade_speed = 10f;
    public bool is_inhouse = false;
    public List<GameObject> obj_spawner_list;
    public List<GameObject> zombie_spawner_list;

    private bool opened = false;

    //private List<Material> roof_mat;

    void Start () {
        //foreach (GameObject rf in roof)
        //roof_mat.Add(rf.GetComponent<Renderer>().material);
        opened = is_inhouse ? true : opened;
	}

    private void target_alpha(float target)
    {
        foreach (GameObject rf in roof)
        {
            Material mat = rf.GetComponent<Renderer>().material;
            float alpha = mat.color.a;
            if (alpha != target)
            {
                Color tmp = new Color(mat.color.r, mat.color.g, mat.color.b, target);
                mat.color = Color.Lerp(mat.color, tmp, Time.deltaTime * fade_speed);
            }
        }
    }

    void Update()
    {
        if (is_inhouse)
        {
            target_alpha(0f);
        }
        else
        {
            target_alpha(1f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") == true)
            is_inhouse = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") == true)
            is_inhouse = false;
    }

    public void opening_house()
    {
        if (!opened)
        {
            foreach (GameObject obj in obj_spawner_list)
            {
                obj.GetComponent<object_spawner>().is_activated = true;
            }
            foreach (GameObject obj in zombie_spawner_list)
            {
                obj.GetComponent<zombie_spawner>().is_active = true;
            }
        }
    }
}
