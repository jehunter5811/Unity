using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBalloonsController : MonoBehaviour {

	public GameObject balloonPrefab;
	public float balloonSpeed = 3f;
	public float firingRate = 1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float probability = firingRate * Time.deltaTime;
		if (GameObject.FindGameObjectWithTag ("Player").transform.position.x <= transform.position.x && Random.value < probability) {
			FireBalloonLeft ();
		} else if (GameObject.FindGameObjectWithTag ("Player").transform.position.x > transform.position.x && Random.value < probability) {
			FireBalloonRight ();
		}
	}

	void FireBalloonLeft () {
		Vector3 posLeft = new Vector3 (transform.position.x - 0.5f, transform.position.y, 0);
		GameObject balloon = Instantiate(balloonPrefab, posLeft, Quaternion.identity);
		balloon.GetComponent<Rigidbody2D>().velocity = new Vector3(-balloonSpeed, 0, 0);
	}

	void FireBalloonRight () {
		Vector3 posRight = new Vector3 (transform.position.x + 0.5f, transform.position.y, 0);
		GameObject balloon = Instantiate(balloonPrefab, posRight, Quaternion.identity);
		balloon.GetComponent<Rigidbody2D>().velocity = new Vector3(balloonSpeed, 0, 0);
	}
}
