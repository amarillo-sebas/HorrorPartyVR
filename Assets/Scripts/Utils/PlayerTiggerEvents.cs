using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTiggerEvents : MonoBehaviour {
	private OnBeginGame beginGameScript;

	void Start () {
		beginGameScript = FindObjectOfType(typeof(OnBeginGame)) as OnBeginGame;
	}

	public void TriggerEvent () {
		beginGameScript.BeginGameEvent();
	}
}
