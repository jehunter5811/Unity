using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Treasure : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.tag == "Player") {
			StartCoroutine ("TreasureWin");
		}
	}

	public IEnumerator TreasureWin () {
		yield return new WaitForSeconds (2);
		SceneManager.LoadScene ("_01");
	}
}
