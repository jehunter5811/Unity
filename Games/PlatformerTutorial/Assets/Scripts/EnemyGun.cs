using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour {
	public GameObject waterPrefab;
	public float waterSpeed = 4f;
	public float firingRate = 1f;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		GunRaycast ();

//		float probability = firingRate * Time.deltaTime;
//		if (Random.value < probability) {
//			FireWater ();
//		} 
	}

	void FireWater () {
//		Vector3 posLeft = new Vector3 (transform.position.x - 0.5f, transform.position.y, 0);
//		GameObject water = Instantiate(waterPrefab, posLeft, Quaternion.identity);
//		water.GetComponent<Rigidbody2D>().velocity = new Vector3(-waterSpeed, 0, 0);
	}

	void GunRaycast() {
		//		RaycastHit2D hitUp = Physics2D.Raycast (transform.position, Vector2.up);
		//		if (hitUp != null && hitUp.collider != null && hitUp.distance < 0.9f && hitUp.collider.tag == "luckyblock") {
		//			Destroy (hitUp.collider.gameObject);
		//		}
		RaycastHit2D hit = Physics2D.Raycast (transform.position, Vector2.left);
		float probability = firingRate * Time.deltaTime;
		if (Random.value < probability && hit != null && hit.collider != null && hit.distance < 12f && hit.collider.tag == "Player") {
			Vector3 posLeft = new Vector3 (transform.position.x - 0.5f, transform.position.y, 0);
			GameObject water = Instantiate(waterPrefab, posLeft, Quaternion.identity);
			water.GetComponent<Rigidbody2D>().velocity = new Vector3(-waterSpeed, 0, 0);
			Debug.Log ("You're close");
		}
	}
}
