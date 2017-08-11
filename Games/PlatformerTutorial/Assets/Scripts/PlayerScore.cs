using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour {

//	public float timeLeft = 120;
	public int playerScore = 0; 
//	public GameObject timeLeftUI;
	public GameObject playerScoreUI;
	public GameObject playerHealthUI;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
//		timeLeft -= Time.deltaTime;
//		timeLeftUI.gameObject.GetComponent<Text> ().text = ("Time Left: " + (int)timeLeft);
		playerScoreUI.gameObject.GetComponent<Text> ().text = ("Score: " + playerScore);
		playerHealthUI.gameObject.GetComponent<Text> ().text = ("Health: " + GetComponent<PlayerHealth>().playerHealth);
//		if (timeLeft < 0.1f) {
//			SceneManager.LoadScene ("_01");
//		}
		if (playerScore >= 300) {
			playerScore = 0;
		}
	}

	void OnTriggerEnter2D (Collider2D trig) {
		if (trig.gameObject.name == "EndLevel") {
			CountScore ();
		} else if (trig.gameObject.tag == "coin") {
			playerScore = playerScore + 10;
			Destroy (trig.gameObject);
		}
	}

	void CountScore() {
//		playerScore = playerScore + (int)(timeLeft * 10);
	}
}
