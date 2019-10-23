using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour {
	public GameObject previousGameObject;
	public Button selectedButton;

	void OnEnable () {
		StartCoroutine(EnableWait());
	}
	IEnumerator EnableWait () {
		yield return null;
		if (selectedButton) {
			selectedButton.Select();
		}
	}
	
	void Update () {
		if (Input.GetButtonDown("Cancel")) {
			if (previousGameObject) {
				previousGameObject.SetActive(true);
				gameObject.SetActive(false);
			}
		}
	}
}
