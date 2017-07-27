using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

	public Text text;
	private enum States {opening, start, mirror, sheets_0, lock_0, cell_mirror, sheets_1, locks_1, freedom};
	private States myState;

	// Use this for initialization
	void Start () {
		myState = States.opening;
	}
	
	// Update is called once per frame
	void Update () {
		print (myState);
		if (myState == States.opening) {
			state_opening ();
		}else if (myState == States.start) {
			state_start ();
		}
	}

	void state_opening () {
		text.text = "You and 3 friends are wanted felons, you need " +
		"enough money to leave the country and start a new life.\n" +
		"Your job is to get through it all WITHOUT getting caught. Good Luck.\n" +
		"Press S to Start";

		if (Input.GetKeyDown(KeyCode.S)) {
				myState = States.start;
		}
	}

	void state_start () {
		text.text = "Time: 3:14 PM \nPlace: Las Vegas, Nevada\nYou've just arrived near the bank.\n" +
					"Are you guys going in with masks on or masks off?\nPress M for Fuck it, Masks Off or press O for Masks on";

		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.opening;
		}
	}
}
