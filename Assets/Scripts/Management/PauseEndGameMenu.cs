using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseEndGameMenu : MonoBehaviour {
	public void RestartLevel () {
		SceneScript.sceneManager.LoadScene(SceneScript.sceneManager.SceneName());
	}

	public void MainMenu () {
		SceneScript.sceneManager.LoadScene("MainMenu");
	}
}
