using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	void Start() {
//		if (SceneManager.GetActiveScene ().buildIndex = 0) {
//			Invoke ("LoadNextLevel", autoLoad);
//		}
//		if (OnSceneChange !=null) {
//			OnSceneChange(SceneManager.GetActiveScene().buildIndex);
//		}
	}

	void LoadNextLevel() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void LoadLevel (string name){
		// Debug.Log("Level load requested for: " + name);
		SceneManager.LoadScene(name);
		}
		
	public void QuitRequest (){
		Application.Quit();
		}
		
}
