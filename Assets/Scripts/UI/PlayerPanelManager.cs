using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPanelManager : MonoBehaviour {
	public Image image;

	public Color buttonDisabledColor;
	public Color buttonEnableddColor;

	void Start () {
		ButtonState(false);
	}
	
	public void ChangeTeam (Sprite s) {
		image.sprite = s;
	}

	public void ButtonState (bool b) {
		if (b) image.color = buttonEnableddColor;
		else image.color = buttonDisabledColor;
	}
}
