using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

	void Update () {
		if (gameObject.transform.position.y < -50) {
			Destroy (gameObject);
		}
	}

	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.tag == "fireball") {
			Destroy (gameObject);
		}
	}
}
