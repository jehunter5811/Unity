using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroEnemy : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody2D>().velocity = new Vector3 (3, 0, 0);
	}

	void OnTriggerEnter2D (Collider2D trig) {
		if (trig.gameObject.tag == "shredder") {
			Destroy (gameObject);
		}
	}
}
