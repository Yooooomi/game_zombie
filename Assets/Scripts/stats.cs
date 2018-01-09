using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stats : MonoBehaviour {
	public float moveSpeed;
    public float sprintMultiplier;
	public float maxHealth;
	public float curHealth;

    public void deal_damages(int dmg)
    {
        curHealth -= dmg;
        if (curHealth <= 0)
        {
            Debug.Log("Dead !");
        }
    }
}
