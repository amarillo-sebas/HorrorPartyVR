using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RespawnText : MonoBehaviour {
	[Space(5f)]
	[Header("Dependencies")]
	public TextMeshProUGUI text;

	[Space(5f)]
	[Header("Variables")]
	public int timeCounter;

	void Start () {
		text.text = "";
	}

	public void Engage (int t) {
		timeCounter = t;
		text.text = timeCounter + "";
		StartCoroutine(Count());
	}

	IEnumerator Count () {
		yield return new WaitForSeconds(1f);
		timeCounter--;
		text.text = timeCounter + "";
		if (timeCounter > 0) StartCoroutine(Count());
		else text.text = "";
	}
}
