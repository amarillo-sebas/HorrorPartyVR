using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMapButton : MonoBehaviour {
	public string mapName;

	public void LoadMap () {
		SceneManager.LoadScene(mapName);
	}
}
