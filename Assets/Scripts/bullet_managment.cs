using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_managment : MonoBehaviour {

    public float bullet_speed = 50f;
    public Vector3 vect_speed;

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player") && !collision.collider.isTrigger)
        {
            Destroy(this.gameObject);
            Debug.Log(collision.gameObject.name);
        }
    }
	
	// Update is called once per frame
	void Update () {
        Destroy(this.gameObject, 2f);
        transform.position += vect_speed * bullet_speed * Time.deltaTime;
	}
}
