using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerProjectile : MonoBehaviour {

	//public float GetDamage() {
	//	return damage;
	//}

	public void Hit() {
		Destroy(gameObject);
	}
}
