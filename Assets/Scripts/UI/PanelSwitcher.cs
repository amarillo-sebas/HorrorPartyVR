using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelSwitcher : MonoBehaviour {
	public GameObject panelGameObject;
	public GameObject switchToGameObject;

	public void SwitchPanel () {
		if (switchToGameObject) {
			switchToGameObject.SetActive(true);
			panelGameObject.SetActive(false);
		}
	}

	public void GoToPlayerSelect (string s) {
		PlayerSelectManager psm;
		psm = FindObjectOfType(typeof(PlayerSelectManager)) as PlayerSelectManager;
		psm.previousGameObject = panelGameObject;
		//psm.Init(s);
	}
}
