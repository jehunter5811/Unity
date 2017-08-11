using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperPlane : MonoBehaviour {

	public int planeSpeed = 5;
	public int xMoveDirection = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
//		int timeSince = (int)Time.deltaTime * 2;
		gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (xMoveDirection, 0) * planeSpeed;
//		if (timeSince >= 200) {
//			Debug.Log ("Flip");
//		}
		if (xMoveDirection > 0) {
			StartCoroutine ("CountOne");
		} else if (xMoveDirection < 0) {
			StartCoroutine ("CountTwo");
		}

	}

	void FlipPlane() {
		if (xMoveDirection > 0) {
			xMoveDirection = -1;
		} else {
			xMoveDirection = 1;
		}
	}

	public IEnumerator CountOne () {
		yield return new WaitForSeconds (2);
		xMoveDirection = -1;
	}

	public IEnumerator CountTwo () {
		yield return new WaitForSeconds (2);
		xMoveDirection = 1;
	}
}
