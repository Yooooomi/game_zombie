using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stats : MonoBehaviour {
	public float moveSpeed;
    public float sprintMultiplier;
	public float maxHealth;
    public float maxhealth_boosted;
	public float curHealth;

    public float to_maxhealth_speed;

    public void add_health(float health)
    {
        curHealth += health;
        if (health > maxhealth_boosted)
        {
            health = maxhealth_boosted;
        }
    }

    public void deal_damages(float dmg)
    {
        curHealth -= dmg;
        if (curHealth <= 0)
        {
            Debug.Log("Dead !");
        }
    }

    void Update()
    {
        if (curHealth > maxHealth)
        {
            curHealth -= to_maxhealth_speed * Time.deltaTime;
            if (curHealth < maxHealth)
                curHealth = maxHealth;
        }
    }
}
