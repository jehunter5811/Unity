using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D (Collision2D col) {
		//TODO Animate splashes from water balloons
		if (col.gameObject.tag == "ground" || col.gameObject.tag == "Player" || col.gameObject.tag == "luckyblock" || col.gameObject.tag == "enemy" || col.gameObject.tag == "fireball"){
			Destroy (gameObject);
		}
	}
}
