using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	public bool autoPlay = false;
	public float speed = 1.0f;
	private bool keyBoardInput = false;

	private Ball ball;

	void Start() {
		ball = GameObject.FindObjectOfType<Ball>(); 
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Return)) {
			keyBoardInput = true;
		} else if (Input.GetKeyDown(KeyCode.Tab)){
			keyBoardInput = false;
		}

		if (!autoPlay) {
			GamePlay();
		} else {
			AutoPlay();
		}

	}

	void OnCollisionEnter2D(Collision2D collision) {
		AudioSource audio = GetComponent<AudioSource>();
		audio.Play();
	}

	void AutoPlay() {
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);
		Vector3 ballPos = ball.transform.position;
		paddlePos.x = Mathf.Clamp(ballPos.x, 1.0f, 15.0f);
		
		this.transform.position = paddlePos;
	}

	void GamePlay () {
		if (!keyBoardInput) {
			MoveWithMouse();
		} else {
			MoveWithKeys();
		}
	}

	void MoveWithMouse () {
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
		
		paddlePos.x = Mathf.Clamp(mousePosInBlocks, 1.0f, 15.0f);
		
		this.transform.position = paddlePos;
	}

	//Use this for keyboard input rather than mouse (note: Y movement needs to be removed)

	void MoveWithKeys () {
		Vector3 paddlePos = new Vector3 (Input.GetAxis("Horizontal"), 0f, 0f);
		
		transform.position += paddlePos * speed * Time.deltaTime;

		//This is where I'll set keyboard rotation option for the paddle. 
		//if (Input.GetKeyDown("space")) {
		//	print ("Space");
		//}
	}
}
