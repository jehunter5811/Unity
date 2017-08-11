using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Missiles : MonoBehaviour {

	public int missileCount;

	void Start()
	{
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

	void Update() {
		print (missiles);
	}

}
