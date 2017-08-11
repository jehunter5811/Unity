using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {

	public float health = 200f;

	public GameObject enemyBulletPrefab;
	public float projectileSpeed;
	public float firingRate = 2f;

	void FireBullet () {
		Vector3 startPosition = transform.position + new Vector3(0, -0.5f, 0);
		GameObject bullet = Instantiate(enemyBulletPrefab, startPosition, Quaternion.identity);
		bullet.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -projectileSpeed, 0);

	}

	void OnTriggerEnter2D(Collider2D collision) {
		Projectile missile = collision.gameObject.GetComponent<Projectile>();
		BulletProjectile bullet = collision.gameObject.GetComponent<BulletProjectile>();
		if (missile) {
			health = health - missile.GetDamage();
			missile.Hit();
			if (health <=0) {
				Destroy(gameObject);
			}
		}else if (bullet) {
			health = health - bullet.GetDamage();
			bullet.Hit();
			if (health <=0) {
				Destroy(gameObject);
			}
		}
	}

	void Update () {
		float probability = firingRate * Time.deltaTime;
		if(Random.value < probability) {
			FireBullet();
		}
		//InvokeRepeating("FireBullet", 0.000001f, firingRate);
	}

}
