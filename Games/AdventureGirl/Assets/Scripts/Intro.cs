using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour {

	public Animator anim;
	public float playerJumpPower;
	public float spriteSpeed = 4f;
	public GameObject badguyPrefab;

	private bool grounded = true;

	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D> ();
		StartCoroutine ("Run");

	}
	
	// Update is called once per frame
	void Update () {
		rb.velocity = new Vector2 (spriteSpeed, 0);
		GameObject.FindGameObjectWithTag("enemyGuy").GetComponent<Rigidbody2D>().velocity = new Vector3 (3, 0, 0);
	}


	public IEnumerable Run () {
		
		anim.SetFloat("speed", 3f);
		yield return new WaitForSeconds (1.5f);
		GetComponent<Rigidbody2D> ().AddForce (Vector2.up * playerJumpPower);
		anim.SetBool ("jump", true);
		rb.velocity = new Vector2 (0, 0);
		yield return new WaitForSeconds (0.3f);
		anim.SetBool ("shoot", true);
	}

	void OnTriggerEnter2D (Collider2D trig) {
		if (trig.gameObject.tag == "shredder") {
			Destroy (gameObject);
		}
	}
}
