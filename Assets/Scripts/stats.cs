﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stats : MonoBehaviour {
    private data_center dc;

	public float moveSpeed;
    public float sprintMultiplier;
	public float maxHealth;
    public float maxhealth_boosted;
	public float curHealth;

    public float to_maxhealth_speed;

    void Start()
    {
        dc = GetComponent<data_center>();
        dc.ui.refresh_health();
    }

    public void add_health(float health)
    {
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
