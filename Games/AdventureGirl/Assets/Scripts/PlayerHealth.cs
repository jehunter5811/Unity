using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	public int playerHealth = 3;
	public float playerBounce = 500;
	public GameObject healthUI;

	private Vector2 playerPos;
	private Animator anim;
	private bool _isDead = false;

	void Start () {
		anim = GetComponent<Animator> ();
	}

	void Update () {

		if (playerHealth <= 0) {
			_isDead = true;
			//dead audio
		}

		if (_isDead == true) {
			anim.SetBool ("dead", true);
			StartCoroutine ("Die");
		}

		if (transform.position.y < -7.5) {
			//audio die
			StartCoroutine ("Die");
		}

		healthUI.gameObject.GetComponent<Text> ().text = ("" + playerHealth);
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "enemyGuy") {
			//health audio
			playerHealth = playerHealth - 1;
			GetComponent<Rigidbody2D>().AddForce (Vector2.up * playerBounce);
			StartCoroutine ("Rotate");
		}
		if (coll.gameObject.tag == "tomato") {
			Destroy(GameObject.FindGameObjectWithTag ("tomato").gameObject);
			playerHealth = playerHealth - 1;
		}
	}

	public IEnumerator Rotate () {
		transform.Rotate (0, 0, 36); //1
		yield return new WaitForSeconds (0.1f);
		transform.Rotate (0, 0, 36); //2
		yield return new WaitForSeconds (0.1f);
		transform.Rotate (0, 0, 36); //3
		yield return new WaitForSeconds (0.1f);
		transform.Rotate (0, 0, 36); //4
		yield return new WaitForSeconds (0.1f);
		transform.Rotate (0, 0, 36); //5
		yield return new WaitForSeconds (0.1f);
		transform.Rotate (0, 0, 36); //6
		yield return new WaitForSeconds (0.1f);
		transform.Rotate (0, 0, 36); //7
		yield return new WaitForSeconds (0.1f);
		transform.Rotate (0, 0, 36); //8
		yield return new WaitForSeconds (0.1f);
		transform.Rotate (0, 0, 36); //9
		yield return new WaitForSeconds (0.1f);
		transform.Rotate (0, 0, 36); //10
	}

	public IEnumerator Die () {
		yield return new WaitForSeconds (2f);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
