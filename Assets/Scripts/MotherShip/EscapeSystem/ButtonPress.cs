using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using VRTK.UnityEventHelper;

public class ButtonPress : MonoBehaviour {
	private VRTK_Button_UnityEvents buttonEvents;
	private bool _pressed = false;
	private MeshRenderer rend;

	public Material unpressedMaterial;
	public Material pressedMaterial;

	public AirlockManager am;
	public int buttonID;

	void Start () {
		rend = GetComponent<MeshRenderer>();
	}

	public void ButtonPush () {
		_pressed = !_pressed;
		am.ChangeButtonState(_pressed, buttonID);
		if (_pressed) {
			rend.material = pressedMaterial;
		} else {
			rend.material = unpressedMaterial;
		}
	}
}
