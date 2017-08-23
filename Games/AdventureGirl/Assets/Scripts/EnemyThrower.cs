using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyThrower : MonoBehaviour {

	public GameObject tomatoPrefab;
	public float tomatoSpeed = 3f;
	public float firingRate = 1f;
	public float tomatoLaunch = 350;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		float probability = firingRate * Time.deltaTime;
		if (GameObject.FindGameObjectWithTag ("Player").transform.position.x <= transform.position.x && Random.value < probability) {
			FireTomatoLeft ();
		} else if (GameObject.FindGameObjectWithTag ("Player").transform.position.x > transform.position.x && Random.value < probability) {
			FireTomatoRight ();
		}
	}

	void FireTomatoLeft () {
		Vector3 posLeft = new Vector3 (transform.position.x - 0.5f, transform.position.y, 0);
		GameObject tomato = Instantiate(tomatoPrefab, posLeft, Quaternion.identity);
		tomato.GetComponent<Rigidbody2D>().velocity = new Vector3(-tomatoSpeed, 0, 0);
		tomato.GetComponent<Rigidbody2D> ().AddForce (Vector2.up * tomatoLaunch);
	}

	void FireTomatoRight () {
		Vector3 posRight = new Vector3 (transform.position.x + 0.5f, transform.position.y, 0);
		GameObject tomato = Instantiate(tomatoPrefab, posRight, Quaternion.identity);
		tomato.GetComponent<Rigidbody2D>().velocity = new Vector3(tomatoSpeed, 0, 0);
		tomato.GetComponent<Rigidbody2D> ().AddForce (Vector2.up * tomatoLaunch);
	}
}