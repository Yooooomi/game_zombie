using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stats : MonoBehaviour {
    private data_center dc;

	public float moveSpeed;
    public float sprintMultiplier;
	public float maxHealth;
    public float maxhealth_boosted;
	public float curHealth;
    public int points;
    public int perk_coins;

    public float to_maxhealth_speed;

    void Start()
    {
        dc = GetComponent<data_center>();
        dc.ui.refresh_health();
        dc.ui.refresh_points();
    }

    private float get_real_health(float health)
    {
        for (int i = 0; i < dc.func_health.Count; i++)
        {
            health = dc.func_health[i].func(health);
        }
        for (int i = 0; i < dc.func_health_malus.Count; i++)
        {
            health = dc.func_health_malus[i].func(health);
        }
        return (health);
    }

    public void remove_coin_perks(int amount)
    {
        perk_coins -= amount;
    }

    public void add_health(float health)
    {
        health = get_real_health(health);
        curHealth += health;
        if (health > maxhealth_boosted)
        {
            health = maxhealth_boosted;
        }
        dc.ui.refresh_health();
    }

    public void deal_damages(float dmg)
    {
        curHealth -= dmg;
        if (curHealth <= 0)
        {
            Debug.Log("Dead !");
        }
        dc.ui.refresh_health();
    }

    public void add_points(int point_added)
    {
        points += point_added;
    }

    void Update()
    {
        dc.dot.call_dot(dc);
        if (curHealth > maxHealth)
        {
            curHealth -= to_maxhealth_speed * Time.deltaTime;
            if (curHealth < maxHealth)
                curHealth = maxHealth;
            dc.ui.refresh_health();
        }
    }
}
