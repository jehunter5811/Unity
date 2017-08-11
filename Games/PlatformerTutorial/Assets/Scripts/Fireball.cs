using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {

	public float flameRange = 10f;
	public bool bigFire = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		FireDestroy ();
		if (GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ().lighterCount >= 1) {
			StartCoroutine ("BigFire");
		} else if (GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ().lighterCount <= 0) {
			flameRange = 10f;
		}
	}

	void OnCollisionEnter2D (Collision2D col) {
		//TODO Animate splashes from water balloons
		if (col.gameObject.tag == "waterdrop" || col.gameObject.tag == "waterballoon" || col.gameObject.tag == "luckyblock" || col.gameObject.tag == "ground" || col.gameObject.tag == "enemy"){
			Destroy (gameObject);
		}

		if (col.gameObject.tag == "enemy") {
			GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerScore> ().playerScore = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerScore> ().playerScore + 100;
		}
	}

	void FireDestroy () {
		float posFire = transform.position.x;
		float playerPosLeft = GameObject.FindGameObjectWithTag ("Player").transform.position.x - flameRange;
		float playerPosRight = GameObject.FindGameObjectWithTag ("Player").transform.position.x + flameRange;
		//TODO Animate fire puffing away
		if (posFire > playerPosRight) {
//			Debug.Log ("Later Fireball Right");
			Destroy(gameObject);
		} else if (posFire < playerPosLeft) {
//			Debug.Log ("Bingo");
			Destroy(gameObject);
		}
	}

	public IEnumerator BigFire () {
		flameRange = 20f;
		//TODO Need to display indicator of powerup
//		Debug.Log (flameRange);
		yield return new WaitForSeconds (2);
		GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ().lighterCount = 0;
//		Debug.Log (flameRange);
	}
		
}

