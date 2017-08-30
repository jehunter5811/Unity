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
//		anim.SetBool ("isClose", false);
	}

	void OnTriggerEnter (Collider coll) {
		if (coll.gameObject.tag == "Player") {
			anim.SetBool ("isClose", true);
			StartCoroutine ("ZombieAttack");
		}
	}

	IEnumerator ZombieAttack () {
		yield return new WaitForSeconds (0.5f);
		anim.SetBool ("isClose", false);
	}
}
