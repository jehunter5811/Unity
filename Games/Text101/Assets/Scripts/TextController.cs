using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

	public Text text;
	private enum States {opening, start, masks_on, masks_off, front_entrance, 
						back_entrance, kill_woman, let_her_go, sewer, leave_them, jail};
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
		}else if (myState == States.masks_on) {
			state_masks_on ();
		}else if (myState == States.masks_off) {
			state_masks_off ();
		}else if (myState == States.front_entrance) {
			state_front_entrance ();
		}else if (myState == States.back_entrance) {
			state_back_entrance ();
		}else if (myState == States.kill_woman) {
			state_kill_woman ();
		}else if (myState == States.let_her_go) {
			state_let_her_go ();
		}else if (myState == States.sewer) {
			state_sewer ();
		}else if (myState == States.leave_them) {
			state_leave_them ();
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

		if (Input.GetKeyDown(KeyCode.O)) {
			myState = States.masks_on;
		} 
		
		else if (Input.GetKeyDown(KeyCode.M)) {
			myState = States.masks_off;
		}
	}
	
	//Masks On Choice
	
	void state_masks_on () {
		text.text = "The guard who watches the cameras has just went for his 45 minute break. This is your chance. " +
					"You have the option to either go into the front entrance or the back entrance, there's a guard at each.\n" +
					"Press F for Front Entrance, or Press B for Back Entrance";

		if (Input.GetKeyDown(KeyCode.F)) {
			myState = States.front_entrance;
		}
		
		else if (Input.GetKeyDown(KeyCode.B)) {
			myState = States.back_entrance;
		}
	}
	
	///////////Masks Off Choice == Jail /////////////
	
	void state_masks_off () {
		text.text = "You idiot, a cop recognised you. You've all been captured and sent to jail.\n" +
					"Press S to start over."; 

		if (Input.GetKeyDown(KeyCode.S)) {
			myState = States.start;
		}
	}
	
	//Front Entrance Choice
	
	void state_front_entrance () {
		text.text = "You must take out the front guard with a sniper rifle. You fire and " +
					"an elderly woman saw you kill the guard. She's panicking and trying to get away. What do you do" +
					"Press K for Kill Her, or Press L for Let Her Go";

		if (Input.GetKeyDown(KeyCode.K)) {
			myState = States.kill_woman;
		}
		
		else if (Input.GetKeyDown(KeyCode.K)) {
			myState = States.let_her_go;
		}
	}
	
	//Back Entrance Choice
	
	void state_back_entrance () {
		text.text = "The guard who watches the cameras has just went for his 45 minute break. This is your chance. " +
					"You have the option to either go into the front entrance or the back entrance, there's a guard at each.\n" +
					"Press F for Front Entrance, or Press B for Back Entrance";

		if (Input.GetKeyDown(KeyCode.F)) {
			myState = States.masks_on;
		}
	}
	
	//Kill Woman Choice
	
	void state_kill_woman () {
		text.text = "Now what are you going to do with the woman's and the guard's bodies since you've shot them. \n" +
					"Press T for Sewer or Press A to leave them there.";

		if (Input.GetKeyDown(KeyCode.T)) {
			myState = States.sewer;
		}
		
///		else if (Input.GetKeyDown(KeyCode.A)) {
///		myState = States.leave_them;
///	}
	}
	
	///Let Woman Go Choice
	
	void state_let_her_go () {
		text.text = "Now what are you going to do with the woman's and the guard's bodies since you've shot them. \n" +
					"Press T for Sewer or Press A to leave them there.";

		if (Input.GetKeyDown(KeyCode.T)) {
			myState = States.sewer;
		}
		
		else if (Input.GetKeyDown(KeyCode.A)) {
			myState = States.leave_them;
		}
	}
	
	//Sewer Choice
	
	void state_sewer () {
		text.text = "Now what are you going to do with the woman's and the guard's bodies since you've shot them. \n" +
					"Press T for Sewer or Press A to leave them there.";

		if (Input.GetKeyDown(KeyCode.T)) {
			myState = States.sewer;
		}
		
		else if (Input.GetKeyDown(KeyCode.A)) {
			myState = States.leave_them;
		}
	}
	
	//Leave them choice
	
	void state_leave_them () {
		text.text = "Now what are you going to do with the woman's and the guard's bodies since you've shot them. \n" +
					"Press T for Sewer or Press A to leave them there.";

		if (Input.GetKeyDown(KeyCode.T)) {
			myState = States.sewer;
		}
		
		else if (Input.GetKeyDown(KeyCode.A)) {
			myState = States.leave_them;
		}
	}
}
