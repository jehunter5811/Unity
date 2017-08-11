using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed = 10f;
	public float padding = 1f;
	public GameObject missilePrefab;
	public GameObject bulletPrefab;
	public GameObject powerUpPrefab;
	public float projectileSpeed = 2f;
	public float powerUpSpeed;
	public float firingRate = 0.2f;
	public float health = 250f;
	public static int missileCount;

	private int refresh;


	float xmin;
	float xmax;
	//private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		//rb = GetComponent<Rigidbody2D>();

		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));

		xmin = leftmost.x + padding;
		xmax = rightmost.x - padding;
		missileCount = 3;
	}

	void FireMissile () {
		GameObject missile = Instantiate(missilePrefab, transform.position, Quaternion.identity);
		missile.GetComponent<Rigidbody2D>().velocity = new Vector3(0, projectileSpeed, 0);
	}

	void FireBullet () {
		GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
		bullet.GetComponent<Rigidbody2D>().velocity = new Vector3(0, projectileSpeed, 0);

	}
	
	// Update is called once per frame
	void Update () {

		//Controls the player sprite
		var move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
		transform.position += move * speed * Time.deltaTime;

		//Restrict player to game space
		float newX = Mathf.Clamp (transform.position.x, xmin, xmax);
		transform.position = new Vector3 (newX, transform.position.y, transform.position.z);

		if(Input.GetKeyDown("space")) {
			//Creates missile at playe position when player presses space
			if (missileCount > 0){
				FireMissile();
				missileCount = missileCount - 1;
			} 
		}

		if(Input.GetKeyDown(KeyCode.Tab)) {
			InvokeRepeating("FireBullet", 0.000001f, firingRate);
		}

		if(Input.GetKeyUp(KeyCode.Tab)) {
			CancelInvoke("FireBullet");
		}
 
	}



	void OnTriggerEnter2D(Collider2D collision) {
		EnemyProjectile missile = collision.gameObject.GetComponent<EnemyProjectile>();
		if (missile) {
			health = health - missile.GetDamage();
			missile.Hit();
			if (health <=0) {
				Destroy(gameObject);
			}
		}
		PowerProjectile power = collision.gameObject.GetComponent<PowerProjectile>();
		if (power) {
			missileCount = 3;
			power.Hit();
		}
	}
}
