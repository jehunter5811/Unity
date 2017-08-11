using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

	public float autoLoad;
	public delegate void SceneChange (int level);
//	public static event SceneChange OnSceneChange;

//	private AudioSource audioSource;
//
	// Use this for initialization
	void Awake () {
		DontDestroyOnLoad(gameObject);
//		OnSceneChange += MusicChange;
	}

	void Start () {
//		audioSource = GetComponent<AudioSource> ();
		Invoke ("LoadNextLevel", autoLoad);
	}

	void LoadNextLevel() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}


}
