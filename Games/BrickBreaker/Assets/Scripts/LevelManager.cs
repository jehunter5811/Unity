using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void LoadLevel (string name){
		// Debug.Log("Level load requested for: " + name);
		Brick.breakableCount = 0;
		SceneManager.LoadScene(name);
		//Application.LoadLevel (name);
		}
		
	public void QuitRequest (){
		Application.Quit();
		}

	public void LoadNextLevel() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		Brick.breakableCount = 0;
	}
		
	public void BrickDestroyed() {
		if (Brick.breakableCount <=0) {
		    LoadNextLevel();
		}
	}
}
