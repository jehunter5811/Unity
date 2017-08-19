using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour {

	public GameObject player;
	public Vector3 offset;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (player.transform.position.x + offset.x, player.transform.position.y + offset.y, offset.z); // Camera follows the player with specified offset position
	}
}
