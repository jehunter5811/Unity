using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	private Paddle paddle;
	
	public bool hasStarted = false;
	
	private Vector3 paddleToBallVector;
	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {

		paddle = GameObject.FindObjectOfType<Paddle>();
		rb = GetComponent<Rigidbody2D>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (!hasStarted) {
			// Lock the ball relative to the paddle
			this.transform.position = paddle.transform.position + paddleToBallVector;
		
			// Wait for a mouse press to launch
			if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("space")){
				hasStarted = true;
		
				rb.velocity = new Vector2(2f, 10f);
		}
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		//print ("Collision");
		Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));

		if (hasStarted) {
			//print ("It works!");
			//AudioSource audio = GetComponent<AudioSource>();
	  //      audio.Play();
			rb.velocity += tweak;
		}
	}
}
