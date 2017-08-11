using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighter : MonoBehaviour {

	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.tag == "Player") {
			GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().lighterCount = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().lighterCount + 1;
			Destroy (gameObject);
		}
	}
}
