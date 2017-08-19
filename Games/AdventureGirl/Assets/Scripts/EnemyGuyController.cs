using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGuyController : MonoBehaviour {

	public bool facingLeft = true;
	public float speed = 2f;
	public int enemyGuyHealth = 2;
	public float enemyGuyBounce = 10f;

	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (facingLeft == true) {
			rb.velocity = new Vector2 (-speed, rb.velocity.y);
		} else if (facingLeft == false) {
			rb.velocity = new Vector2 (speed, rb.velocity.y);
		}

		if (enemyGuyHealth <= 0) {
			EnemyDie ();
		}
			
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "bullet") {
			enemyGuyHealth = enemyGuyHealth - 2;
			Destroy (GameObject.FindGameObjectWithTag ("bullet"));
		}

		if (coll.gameObject.tag == "Player" && Input.GetKeyDown (KeyCode.RightShift)) {
			enemyGuyHealth = enemyGuyHealth - 1;
		}
	}

	void OnTriggerEnter2D (Collider2D trig) {
		if (trig.gameObject.tag == "shredder") {
			Destroy (gameObject);
		}

		if (trig.gameObject.tag == "end") {
			FlipEnemy ();
		}
	}

	void FlipEnemy() {
		facingLeft = !facingLeft;
		Vector2 localScale = gameObject.transform.localScale;
		localScale.x *= -1;
		transform.localScale = localScale;
	}

	void EnemyDie() {
		GetComponent<Rigidbody2D>().AddForce (Vector2.up * enemyGuyBounce);
		GetComponent<CircleCollider2D> ().isTrigger = true;
		StartCoroutine ("Rotate");
	}

	public IEnumerator Rotate () {
		transform.Rotate (0, 0, 36); //1
		yield return new WaitForSeconds (0.1f);
		transform.Rotate (0, 0, 36); //2
		yield return new WaitForSeconds (0.1f);
		transform.Rotate (0, 0, 36); //3
		yield return new WaitForSeconds (0.1f);
		transform.Rotate (0, 0, 36); //4
		yield return new WaitForSeconds (0.1f);
		transform.Rotate (0, 0, 36); //5
		yield return new WaitForSeconds (0.1f);
		transform.Rotate (0, 0, 36); //6
		yield return new WaitForSeconds (0.1f);
		transform.Rotate (0, 0, 36); //7
		yield return new WaitForSeconds (0.1f);
		transform.Rotate (0, 0, 36); //8
		yield return new WaitForSeconds (0.1f);
		transform.Rotate (0, 0, 36); //9
		yield return new WaitForSeconds (0.1f);
		transform.Rotate (0, 0, 36); //10
		GetComponent<CircleCollider2D> ().enabled = true;
	}
}
