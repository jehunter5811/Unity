using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChanger : MonoBehaviour {

	public Sprite Right;
	public Sprite Left;
	public Sprite Normal;
	SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("left")){
			spriteRenderer.sprite = Left;
		} else if (Input.GetKey("right")) {
			spriteRenderer.sprite = Right;
		}else{
	        spriteRenderer.sprite = Normal;
	    }
     }

}
