using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider) {
		BasicLaser laser = collider.gameObject.getComponent<Projectile>();
		if(laser) {
			Debug.Log("Hit By a Laser");
		}
		
	}


}
