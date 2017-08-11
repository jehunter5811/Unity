using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void LoadLevel (string name){
		// Debug.Log("Level load requested for: " + name);
		SceneManager.LoadScene(name);
		//Application.LoadLevel (name);
		}
		
	public void QuitRequest (){
		Application.Quit();
		}

	public void LoadNextLevel() {
		if (EnemySpawner.enemyCount == 0) {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
	}
		
}
