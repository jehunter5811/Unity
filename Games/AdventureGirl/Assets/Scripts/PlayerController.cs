using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float runSpeed = 4; // player left right walk speed
	public int playerJumpPower = 500;
	public GameObject bulletPrefab;
	public GameObject coinPrefab;
	public float bulletSpeed = 2f;
	public int bulletCount = 8;
	public GameObject silverUI;
	public GameObject goldUI;
	public GameObject springPrefab;

	public int goldCount;
	public int silverCount = 0;
	private bool _isGrounded = true;
	private float moveX;
	private bool facingRight = true;
	private Rigidbody2D rb;
	Animator animator;
	private Animator anim;


	void Awake() {
//		DontDestroyOnLoad (gameObject);
	}
	// Use this for initialization
	void Start()
	{
		//define the animator attached to the player
		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
	}


	void FixedUpdate()
	{
		float h = Input.GetAxis("Horizontal");
		rb.velocity = new Vector2 (h * runSpeed, rb.velocity.y);
		anim.SetFloat("speed", Mathf.Abs(rb.velocity.x));
		anim.SetBool ("grounded", _isGrounded);
		if (h < 0 && facingRight) {
			FlipPlayer ();
		} else if (h > 0 && !facingRight) {
			FlipPlayer ();
		}

		if (Input.GetButtonDown ("Jump") && _isGrounded == true) {
			GetComponent<Rigidbody2D>().AddForce (Vector2.up * playerJumpPower);
			_isGrounded = false;
		}
		//TODO make bullets shoot left too
		if (Input.GetKeyDown (KeyCode.Return) && bulletCount > 0) {
			anim.SetBool ("shoot", true);
			if (facingRight == true) {
				Vector3 posRight = new Vector3 (transform.position.x + 0.5f, transform.position.y, 0);
				GameObject bullet = Instantiate(bulletPrefab, posRight, Quaternion.identity);
				bullet.GetComponent<Rigidbody2D> ().velocity = new Vector3 (bulletSpeed, 0, 0);
			} else {
				Vector3 posLeft = new Vector3 (transform.position.x - 0.5f, transform.position.y, 0);
				GameObject bullet = Instantiate(bulletPrefab, posLeft, Quaternion.identity);
				bullet.GetComponent<Rigidbody2D> ().velocity = new Vector3 (-bulletSpeed, 0, 0);
			}
		} else {
			anim.SetBool ("shoot", false);
		}

		if (Input.GetKeyDown (KeyCode.RightShift)) {
			anim.SetBool ("melee", true);
		} else {
			anim.SetBool ("melee", false);
		}



		silverUI.gameObject.GetComponent<Text> ().text = ("" + silverCount);
		goldUI.gameObject.GetComponent<Text> ().text = ("" + goldCount);
	}

	void FlipPlayer() {
		facingRight = !facingRight;
		Vector2 localScale = gameObject.transform.localScale;
		localScale.x *= -1;
		transform.localScale = localScale;
	}





	//--------------------------------------
	// Check if player has collided with the floor
	//--------------------------------------
	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "ground") {
			
			_isGrounded = true;
		}
		if (coll.gameObject.tag == "spring") {
			anim.SetBool("sprung", true);
			GetComponent<Rigidbody2D>().AddForce (Vector2.up * playerJumpPower * 2.5f);
		}
		if (coll.gameObject.tag == "prizeblock") {
			Vector3 springPos = new Vector3 (45.25f, 8.76f, 0);
			GameObject spring = Instantiate (springPrefab, springPos, Quaternion.identity);
			Destroy (GameObject.FindGameObjectWithTag ("prizeblock").gameObject);
		}
	}

	//------------------------------------
	//Check if player collides with treasure chest or coin
	//------------------------------------
	void OnTriggerEnter2D(Collider2D trig) {
		if (trig.gameObject.tag == "treasure") {
			Vector3 coinPos = new Vector3 (GameObject.FindGameObjectWithTag("treasure").GetComponent<BoxCollider2D>().transform.position.x, GameObject.FindGameObjectWithTag("treasure").GetComponent<BoxCollider2D>().transform.position.y + 1.0f, 0);
			GameObject coin = Instantiate(coinPrefab, coinPos, Quaternion.identity);
			//audio here
			Destroy (GameObject.FindGameObjectWithTag ("treasure"));
		}  
		if (trig.gameObject.tag == "coin") {
			//coin noise
			Destroy (GameObject.FindGameObjectWithTag("coin"));
			goldCount = goldCount + 1;
		}

		if (trig.gameObject.tag == "silverCoin") {
			//coin noise
			Destroy (GameObject.FindGameObjectWithTag("silverCoin"));
			silverCount = silverCount + 1;
		}
			
	}
		
}
