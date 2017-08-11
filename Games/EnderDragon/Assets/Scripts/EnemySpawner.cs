using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemyPrefab;
	public GameObject landingStrip;
	public float width;
	public float height;
	public float speed = 2f;
	//public float padding = 1f;
	public static int enemyCount;

	private bool movingRight = false;
	private float xmin;
	private float xmax;

	// Use this for initialization
	void Start () {
		
		//Creating enemies at the positions we defined in the UI creation of the game space
		foreach(Transform child in transform) {
			GameObject enemy = Instantiate(enemyPrefab, child.transform.position,Quaternion.identity) as GameObject;
			enemy.transform.parent = child;
		}

		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftEdge = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		Vector3 rightEdge = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));

		xmin = leftEdge.x;
		xmax = rightEdge.x;
	}

	void OnDrawGizmos() {
		Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
	}
	
	// Update is called once per frame
	void Update () {
		//Controls the enemy sprite
		if (movingRight) {
			transform.position += Vector3.right * speed * Time.deltaTime;
		} else {
			transform.position += Vector3.left * speed * Time.deltaTime;
		}

		float rightEdgeOfFormation = transform.position.x + 3f;
		float leftEdgeOfFormation = transform.position.x - 3f;

		if (leftEdgeOfFormation < xmin) {
			movingRight = true;
		} else if (rightEdgeOfFormation > xmax) {
			movingRight = false;
		}

		if(AllMembersDead()) {
		//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
			GameObject landing = Instantiate(landingStrip, new Vector3(8,11,0),Quaternion.identity) as GameObject;
		}
	}

	bool AllMembersDead() {

		//loops over the transform of every child object in the main object which is the formation
		foreach(Transform childPositionGameObject in transform) {
			if (childPositionGameObject.childCount > 0) {
				return false;
			}
		}
		return true;
	}
}
