using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float walkSpeed = 1; // player left right walk speed
	public float playerJumpPower = 250;
	private bool _isGrounded = true; // is player on the ground?

	Animator animator;

	//some flags to check when certain animations are playing
	bool _isPlaying_slide = false;
	bool _isPlaying_run = false;
	bool _isPlaying_die = false;

	//animation states - the values in the animator conditions
	const int STATE_IDLE = 0;
	const int STATE_RUN = 1;
	const int STATE_JUMP = 2;
	const int STATE_SLIDE = 3;
	const int STATE_DIE = 4;

	string _currentDirection = "right";
	int _currentAnimationState = STATE_IDLE;

	// Use this for initialization
	void Start()
	{
		//define the animator attached to the player
		animator = this.GetComponent<Animator>();
	}

	// FixedUpdate is used insead of Update to better handle the physics based jump
	void FixedUpdate()
	{
		//Check for keyboard input
		if (Input.GetButton ("Jump") && _isGrounded == true) {
			GetComponent<Rigidbody2D> ().AddForce (Vector2.up * playerJumpPower);
			changeState (STATE_JUMP);
			_isGrounded = false;
		} else if (Input.GetKey ("right") && _isGrounded == true) {
			changeState (STATE_RUN);
			transform.Translate (Vector3.right * walkSpeed * Time.deltaTime);
		} else if (Input.GetKeyDown ("right") && _isGrounded == false) {
			changeDirection ("right");
			changeState (STATE_JUMP);
			transform.Translate (Vector3.right * walkSpeed * Time.deltaTime);

		} else if (Input.GetKey (KeyCode.DownArrow) && Input.GetKey ("right") && _isGrounded == true) {
			changeState (STATE_SLIDE);
			transform.Translate (Vector3.right * walkSpeed * Time.deltaTime);

		} else if (Input.GetKey ("right")) {
			transform.Translate (Vector3.right * walkSpeed * Time.deltaTime);
		}

		else {
			if (_isGrounded) {
				changeState (STATE_IDLE);
			}
		}
//		else if (Input.GetKey ("left") && !_isPlaying_hadooken)
//		{
//			changeDirection ("left");
//			transform.Translate(Vector3.left * walkSpeed * Time.deltaTime);
//
//			if(_isGrounded)
//				changeState(STATE_RUN);
//
//		}
//		else
//		{
//			if(_isGrounded)
//				changeState(STATE_IDLE);
//		}

		//check if crouch animation is playing
		if (animator.GetCurrentAnimatorStateInfo (0).IsName ("Slide")) {
			_isPlaying_slide = true;
		} else {
			_isPlaying_slide = false;
		}

		//check if hadooken animation is playing
		if (animator.GetCurrentAnimatorStateInfo (0).IsName ("Die")) {
			_isPlaying_die = true;
		} else {
			_isPlaying_die = false;
		}

		//check if strafe animation is playing
		if (animator.GetCurrentAnimatorStateInfo (0).IsName ("Run")) {
			_isPlaying_run = true;
		} else {
			_isPlaying_run = false;
		}

	}

	//--------------------------------------
	// Change the players animation state
	//--------------------------------------
	void changeState(int state){

		if (_currentAnimationState == state)
			return;

		switch (state) {

		case STATE_RUN:
			animator.SetInteger ("state", STATE_RUN);
			break;

		case STATE_SLIDE:
			animator.SetInteger ("state", STATE_SLIDE);
			break;

		case STATE_JUMP:
			animator.SetInteger ("state", STATE_JUMP);
			break;

		case STATE_IDLE:
			animator.SetInteger ("state", STATE_IDLE);
			break;
		}

		_currentAnimationState = state;
	}

	//--------------------------------------
	// Check if player has collided with the floor
	//--------------------------------------
	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "platform")
		{
			_isGrounded = true;
			changeState(STATE_IDLE);

		}

	}

	//--------------------------------------
	// Flip player sprite for left/right walking
	//--------------------------------------
	void changeDirection(string direction)
	{

		if (_currentDirection != direction)
		{
			if (direction == "right")
			{
				transform.Rotate (0, 180, 0);
				_currentDirection = "right";
			}
			else if (direction == "left")
			{
				transform.Rotate (0, -180, 0);
				_currentDirection = "left";
			}
		}

	}

}