using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class weapon_management : MonoBehaviour {

    public data_center dc;
    public GameObject wp_obj;
    public Camera cam;
    public int index = 0;
    public List<weapon> weapons = new List<weapon>();
    private float time_since_last_shoot = 0;
    public GameObject weapon_box;

    // Use this for initialization
	void Start () {
        weapons.Add(new weapon());
        weapons.Add(new weapon());
    }

    void drop_weapon()
    {
        if (weapons.Count < 2)
            return;
        Vector3 pos = transform.position + transform.forward;
        GameObject obj = Instantiate(weapon_box, pos, Quaternion.identity);
        weapon_taking wp_tak = obj.AddComponent<weapon_taking>();
        wp_tak.spawner = null;
        wp_tak.owner = this.gameObject;
        wp_tak.wp = weapons[index];
        weapons.RemoveAt(index);
        index = index - 1;
        if (index < 0)
            index = 0;
    }

    public void pick_up_weapon(weapon wp)
    {
        if (weapons.Count < 2)
        {
            weapons.Add(wp);
        }
        else
        {
            drop_weapon();
            weapons.Add(wp);
        }
    }

    // Update is called once per frame
    void shoot(weapon wp)
    {
        Vector3 mouse_pos = Input.mousePosition;
        Vector3 direction = wp_obj.transform.forward;
        Ray ray = new Ray(wp_obj.transform.position, direction);
        RaycastHit result;

        Debug.DrawLine(ray.origin, ray.direction * 1000, Color.black);
        if (Physics.Raycast(ray, out result, wp.range))
        {
            if (result.collider.gameObject.CompareTag("Zombie"))
            {
                result.collider.gameObject.GetComponent<zombie_manager>().deal_damages(weapons[index].damages);
            }
            Debug.Log("touché");
        }
        wp.clip_ammo--;
        dc.ui.refresh_weapon();
    }

    void Update() {
        weapon current_weapon = weapons[index];
        bool shooting = CrossPlatformInputManager.GetButton("Fire1");
        bool drop = CrossPlatformInputManager.GetButtonDown("Drop");
        float scroll = CrossPlatformInputManager.GetAxis("Mouse ScrollWheel");

        time_since_last_shoot += Time.deltaTime;
        if (shooting && time_since_last_shoot > current_weapon.fire_rate && current_weapon.can_fire()) {
            shoot(current_weapon);
            time_since_last_shoot = 0;
        }
        if (scroll > 0)
        {
            index = (index + 1) % weapons.Count;
        }
        else if (scroll < 0)
        {
            index = (index - 1) % weapons.Count;
            if (index < 0)
                index = weapons.Count - 1;
        }
        if (scroll != 0)
        {
            dc.ui.refresh_weapon();
        }
        if (drop)
        {
            drop_weapon();
        }
    }
}
