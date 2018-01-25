using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System.Linq;

public class zombie_mvt : MonoBehaviour {

    private Seeker seeker;
    private CharacterController cc;

    public float reload_time = 2;
    public float min_dist;
    private zombie_manager zb_manager;
    private attack_manager att_man;

    private Path path = null;
    private float current_time = 0;
    private int current_index = 0;

    void Start()
    {
        att_man = GetComponent<attack_manager>();
        zb_manager = GetComponent<zombie_manager>();
        cc = GetComponent<CharacterController>();
        seeker = GetComponent<Seeker>();
    }

    void end_path(Path p)
    {
        //Debug.Log("Arrived");
    }

    void Update()
    {
        Vector3 dir;

        current_time += Time.deltaTime;
        if (current_time >= reload_time && att_man.target)
        {
            path = seeker.StartPath(transform.position, att_man.target.transform.position, end_path);
            current_time = 0;
            current_index = 0;
        }
        if (path == null)
            return;
        if (current_index > path.vectorPath.Count - 1)
            return;
        dir = (path.vectorPath[current_index] - transform.position).normalized;
        dir *= zb_manager.stats.speed * Time.deltaTime * 100;

        cc.SimpleMove(dir);
        if (Vector3.Distance(transform.position, path.vectorPath[current_index]) < min_dist)
        {
            current_index++;
        }
    }
}
