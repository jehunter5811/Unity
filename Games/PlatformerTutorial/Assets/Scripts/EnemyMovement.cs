using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	public int EnemySpeed;
	public int xMoveDirection;
	
	// Update is called once per frame
	void Update () {
		RaycastHit2D hit = Physics2D.Raycast (transform.position, new Vector2 (xMoveDirection, 0));
		gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (xMoveDirection, 0) * EnemySpeed;
		if (hit.distance < 0.2f) {
			FlipEnemy ();
		}
		if (hit.collider.tag == "Player") {	
			GameObject.Find("Player").GetComponent<Rigidbody2D> ().AddForce (Vector2.up * 1000);
			GameObject.Find("Player").GetComponent<Rigidbody2D> ().AddForce (Vector2.left * 600);
			GameObject.Find ("Player").GetComponent<PlayerController> ().playerSpeed = 0;
			GameObject.Find("Player").GetComponent<BoxCollider2D>().enabled = false;
		}
	}

	void FlipEnemy() {
		if (xMoveDirection > 0) {
			xMoveDirection = -1;
		} else {
			xMoveDirection = 1;
		}
	}

}
