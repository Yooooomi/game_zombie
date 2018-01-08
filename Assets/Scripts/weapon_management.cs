using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class weapon_management : MonoBehaviour {

    public Camera cam;
    public int index = 0;
    public int nbr_weapon = 1;
    public List<weapon> weapons = new List<weapon>();
    private float time_since_last_shoot = 0;
    // Use this for initialization
	void Start () {
        //weapons.Add(new weapon());
    }

    // Update is called once per frame
    void shoot(weapon wp)
    {
        Vector3 mouse_pos = Input.mousePosition;
        Vector3 direction = cam.ScreenToWorldPoint(mouse_pos);
        direction -= transform.position;
        Ray ray = new Ray(gameObject.transform.position, direction);
        RaycastHit result;

        Debug.DrawLine(ray.origin, ray.direction);
        if (Physics.Raycast(ray, out result, wp.range))
            Debug.Log("touché");
        wp.clip_ammo--;
    }

    void Update() {
        weapon current_weapon = weapons[index];
        bool shooting = CrossPlatformInputManager.GetButton("Fire1");

        time_since_last_shoot += Time.deltaTime;
        if (shooting && time_since_last_shoot > current_weapon.fire_rate && current_weapon.can_fire()) {
            shoot(current_weapon);
            time_since_last_shoot = 0;
        }
    }
}
