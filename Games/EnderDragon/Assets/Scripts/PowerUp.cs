using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

	public GameObject powerUpPrefab;
	public float projectileSpeed;
	public float spawnRate;


	void Spawn () {
		Vector3 startPosition = transform.position + new Vector3(Random.Range(1f, 14f), 0, 0);
		GameObject powerUp = Instantiate(powerUpPrefab, startPosition, Quaternion.identity);
		powerUp.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -projectileSpeed, 0);

	}


	void Start () {
		//float probability = spawnRate * Time.deltaTime;
		//if(Random.value < probability) {
		//	Spawn();
		//}
		InvokeRepeating("Spawn", spawnRate, spawnRate);

	}
}
