using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour {

	private int stuffieCount = 0;
	private SpriteRenderer spriteRenderer; 


	public Sprite spriteJump;

	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	void OnTriggerEnter2D(Collider2D trig) {
		if (trig.gameObject.tag == "stuffie") {
			//end level audio
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
			stuffieCount = stuffieCount + 1;
			GetComponent<PlayerController> ().enabled = false;
			GetComponent<Animator> ().enabled = false;
			spriteRenderer.sprite = spriteJump;
		}
	}
}
