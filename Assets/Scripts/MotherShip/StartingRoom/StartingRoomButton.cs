using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using VRTK.UnityEventHelper;

public class StartingRoomButton : MonoBehaviour {
	public StartingRoomController startingRoomScript;

	private MeshRenderer rend;
	public Material unpressedMaterial;
	public Material pressedMaterial;

	public float buttonCooldownTime;
	private bool _buttonCooldown = false;

	void Start () {
		rend = GetComponent<MeshRenderer>();
	}

	public void ButtonPush () {
		if (!_buttonCooldown) {
			StartCoroutine(ButtonCooldown(buttonCooldownTime));
			startingRoomScript.OpenDoor();
		}
	}

	IEnumerator ButtonCooldown (float t) {
		_buttonCooldown = true;
		rend.material = pressedMaterial;
		yield return new WaitForSeconds(t);
		rend.material = unpressedMaterial;
		_buttonCooldown = false;
	}
}
