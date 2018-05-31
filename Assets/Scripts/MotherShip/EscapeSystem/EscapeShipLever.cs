using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK.UnityEventHelper;
using VRTK;

public class EscapeShipLever : MonoBehaviour {
	public EscapeShipController espaceShip;
	public EscapeShipAudio audio;
	public bool canBlastOff = false;

	public void HandleChange (object sender, Control3DEventArgs e) {
		if (e.value >= 50f) {
			if (canBlastOff) {
				espaceShip.BlastOff();
				audio.BlastOff();
			} else {
				audio.Error();
			}
		}
	}
}
