using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D trig) {
		if (trig.gameObject.tag == "shredder") {
			Destroy (gameObject);
		}
	}
	
	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "enemy") {
				Destroy(gameObject);
		}
	}

}
