using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour {

	Animator animator;
	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter (Collision coll) {
		if (coll.gameObject.tag == "Player") {
			anim.SetBool ("isClose", true);
		} else {
			anim.SetBool ("isClose", false);
		}
	}
}
