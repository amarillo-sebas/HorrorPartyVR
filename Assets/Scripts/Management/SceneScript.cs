using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScript : MonoBehaviour {
	public static SceneScript sceneManager;

	void Awake () {
		if (sceneManager == null) {
			DontDestroyOnLoad(gameObject);
			sceneManager = this;
		}
		else if (sceneManager != this) Destroy(gameObject);
	}

	void OnEnable () {
		SceneManager.sceneLoaded += OnLevelFinishedLoading;
	}
	void OnDisable () {
		SceneManager.sceneLoaded -= OnLevelFinishedLoading;
	}
	void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode) {
		if (scene.name != "MainMenu") {
			//StartCoroutine(Init());
			//_inMainMenu = false;
		} else {
			//_inMainMenu = true;
		}
	}

	public string SceneName () {
		return SceneManager.GetActiveScene().name;
	}
	public void LoadScene (string s) {
		SceneManager.LoadScene(s);
	}

	public void QuitGame () {
		Application.Quit();
	}
}
