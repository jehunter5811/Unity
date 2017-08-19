using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public int playerSpeed = 10;
	public int playerJumpPower = 1250;
	public bool isGrounded;
	public GameObject fireballPrefab;
	public float fireBallSpeed = 2f;
	public int lighterCount = 0;

	private float moveX;
	private bool facingRight;

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
		PlayerMove ();
		PlayerRaycast ();
		if (Input.GetButtonDown ("Jump") && isGrounded == true) {
			Jump ();
		} else if (Input.GetMouseButtonDown (0) && isGrounded == true) {
			Jump ();
		} else if (Input.GetKeyDown ("return") && facingRight == false) {
			//Creates fireball at playe position when player presses space
			FireBallRight ();
		} else if (Input.GetKeyDown ("return") && facingRight == true) {
			FireBallLeft ();
		} else if (Input.GetKeyDown ("up")) {
			FireUp ();
		} 
	}

	void FireBallRight () {
		Vector3 posRight = new Vector3 (transform.position.x + 0.5f, transform.position.y, 0);
		GameObject fireball = Instantiate(fireballPrefab, posRight, Quaternion.identity);
		fireball.GetComponent<Rigidbody2D>().velocity = new Vector3(fireBallSpeed, 0, 0);
	}
	void FireBallLeft () {
		Vector3 posLeft = new Vector3 (transform.position.x - 0.5f, transform.position.y, 0);
		GameObject fireball = Instantiate(fireballPrefab, posLeft, Quaternion.identity);
		fireball.GetComponent<Rigidbody2D>().velocity = new Vector3(-fireBallSpeed, 0, 0);
	}

	void FireUp () {
		Vector3 posUp = new Vector3 (transform.position.x, transform.position.y + 1f, 0);
		GameObject fireball = Instantiate(fireballPrefab, posUp, Quaternion.identity);
		fireball.GetComponent<Rigidbody2D>().velocity = new Vector3(0, fireBallSpeed, 0);
	}

	void PlayerMove () {
		//CONTROLS
		moveX = Input.GetAxis("Horizontal");
		if (Input.GetButtonDown ("Jump") && isGrounded == true) {
			Jump ();
		}

		//ANIMATIONS

		//PLAYER DIRECTION
		if (moveX < 0.0f && facingRight == false) {
			FlipPlayer ();

		} else if (moveX > 0.0f && facingRight == true) {
			FlipPlayer ();

		}

		//PHYSICS
		gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
	}

	void Jump() {
		//JUMPING CODE
		GetComponent<Rigidbody2D>().AddForce (Vector2.up * playerJumpPower);
		isGrounded = false;
	}

	void FlipPlayer() {
		facingRight = !facingRight;
		Vector2 localScale = gameObject.transform.localScale;
		localScale.x *= -1;
		transform.localScale = localScale;
	}

	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.tag == "ground") {
			isGrounded = true;
		}
		if (col.gameObject.tag == "luckyblock") {
			Destroy (col.collider.gameObject);
//			GetComponent<PlayerScore>().playerScore = GetComponent<PlayerScore>().playerScore + 100;
//			GetComponent<PlayerHealth> ().playerHealth = GetComponent<PlayerHealth> ().playerHealth + 1;
////			Debug.Log (GetComponent<PlayerHealth> ().playerHealth);
		}
		//TODO Prototype only: Temporarily load the scene again when winning, need to load next scene in future
		if (col.gameObject.tag == "endlevel") {
			SceneManager.LoadScene ("_01");
		}

		if (col.gameObject.tag == "waterdrop" || col.gameObject.tag == "waterballoon") {
			GetComponent<PlayerHealth> ().playerHealth = GetComponent<PlayerHealth> ().playerHealth - 1;
		}
	}

	void PlayerRaycast() {
//		RaycastHit2D hitUp = Physics2D.Raycast (transform.position, Vector2.up);
//		if (hitUp != null && hitUp.collider != null && hitUp.distance < 0.9f && hitUp.collider.tag == "luckyblock") {
//			Destroy (hitUp.collider.gameObject);
//		}
		RaycastHit2D hit = Physics2D.Raycast (transform.position, Vector2.down);
		if (hit != null && hit.collider != null && hit.distance < 0.9f && hit.collider.tag == "enemy") {
			GetComponent<Rigidbody2D> ().AddForce (Vector2.up * 1000);
			hit.collider.gameObject.GetComponent<Rigidbody2D> ().AddForce (Vector2.right * 200);
			hit.collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
			hit.collider.gameObject.GetComponent<EnemyMovement>().enabled = false;
			GetComponent<PlayerScore>().playerScore = GetComponent<PlayerScore>().playerScore + 100;
		}

//		RaycastHit2D hitEnemyRight = Physics2D.Raycast (transform.position, Vector2.right);
//		RaycastHit2D hitEnemyLeft = Physics2D.Raycast (transform.position, Vector2.left);
//		if (hitEnemyRight != null && hitEnemyRight.collider != null && hitEnemyRight.distance < 0.9f && hitEnemyRight.collider.tag == "enemy") {
//			GetComponent<PlayerHealth> ().playerHealth = GetComponent<PlayerHealth> ().playerHealth - 1;
////			Debug.Log(GetComponent<PlayerHealth> ().playerHealth);
//		} else if (hitEnemyLeft != null && hitEnemyLeft.collider != null && hitEnemyLeft.distance < 0.9f && hitEnemyLeft.collider.tag == "enemy"){
//			GetComponent<PlayerHealth> ().playerHealth = GetComponent<PlayerHealth> ().playerHealth - 1;
////			Debug.Log(GetComponent<PlayerHealth> ().playerHealth);
//		}
	}
}
