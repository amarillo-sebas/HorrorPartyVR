using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class InteractableFlashlight : VRTK_InteractableObject {
	public Light light;

	public override void StartUsing(VRTK_InteractUse usingObject) {
		Debug.Log(" hola");
		base.StartUsing(usingObject);
		light.enabled = !light.enabled;
	}

	public override void StopUsing(VRTK_InteractUse usingObject) {
		base.StopUsing(usingObject);
	}
	
	void Update () {
		base.Update();
	}
}
