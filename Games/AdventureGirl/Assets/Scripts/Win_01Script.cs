using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win_01Script : MonoBehaviour {

	public Camera mainCam;
	public GameObject enemyPrefab;
	public GameObject playerPrefab;
	public int playerJumpPower = 500;

	Animator animator;
	private Animator anim;

	// Use this for initialization
	void Start () {
		GameObject.FindGameObjectWithTag ("enemyGuy").GetComponent<IntroEnemy> ().enabled = false;
		StartCoroutine ("Win");
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public IEnumerator Win () {
		GameObject.FindGameObjectWithTag("stuffie").GetComponent<Transform>().localScale = new Vector3(0.5f, 0.5f, 1);
		yield return new WaitForSeconds (0.25f);
		GameObject.FindGameObjectWithTag("stuffie").GetComponent<Transform>().localScale = new Vector3(0.7f, 0.7f, 1);
		yield return new WaitForSeconds (0.25f);
		GameObject.FindGameObjectWithTag("stuffie").GetComponent<Transform>().localScale = new Vector3(1.0f, 1.0f, 1);
		yield return new WaitForSeconds (0.75f);
		StartCoroutine ("Bad");
	}

	public IEnumerator Bad () {
		mainCam.GetComponent<CameraSystem> ().enabled = false;
		GameObject.FindGameObjectWithTag ("enemyGuy").GetComponent<IntroEnemy> ().enabled = true;
		yield return new WaitForSeconds (0.01f);
		mainCam.transform.position = new Vector3(-17.3f, -0.8f, -10.0f); 
		yield return new WaitForSeconds (1.5f);
		Destroy (GameObject.Find ("WinPlayer").gameObject);
		Destroy (GameObject.FindGameObjectWithTag ("stuffie").gameObject);
		Vector3 playerPos = new Vector3 (131.4149f, 9.9929f, 0);
		GameObject player = Instantiate(playerPrefab, playerPos, Quaternion.identity);
		mainCam.GetComponent<CameraSystem> ().enabled = true;
		player.GetComponent<Rigidbody2D> ().velocity = new Vector3 (4, 0, 0);
		player.GetComponent<Rigidbody2D>().AddForce (Vector2.up * playerJumpPower);
		yield return new WaitForSeconds (2.5f);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
