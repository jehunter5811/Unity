using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

	public int playerHealth = 3;

	// Use this for initialization
	void Start () {
//		playerHealth = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerScore> ().playerScore == 300 && playerHealth < 3) {
			playerHealth = playerHealth + 1;
		}

		if (gameObject.transform.position.y < -7) {
			StartCoroutine ("Die");
		}
		if (playerHealth > 3) {
			playerHealth = 3;
		}
		if (playerHealth < 1) {
//			Destroy (gameObject);
//			StartCoroutine ("DieNow");
			Debug.LogError("You died, man");
		}
	}

	public IEnumerator Die () {
		yield return new WaitForSeconds (1);
		SceneManager.LoadScene ("_01");
	}

	void OnCollisionEnter2D (Collision2D water) {
		if (water.gameObject.tag == "waterbaloon" || water.gameObject.tag == "waterdrop") {
//			Destroy (gameObject);
//			Debug.Log("hit");
		}
	}


}
