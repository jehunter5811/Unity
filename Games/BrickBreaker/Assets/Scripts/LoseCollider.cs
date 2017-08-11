using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour {

	//private LevelManager levelManager;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionEnter2D(Collision2D collision) {
		//print ("Collision");
	}
	
	void OnTriggerEnter2D(Collider2D collide) {
		//print ("Trigger Collide");
		//levelManager = GameObject.FindObjectOfType<LevelManager>();
		SceneManager.LoadScene("Lose");
		//levelManager.LoadLevel("Win");
	}
}
