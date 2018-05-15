using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class InteractableFlashlight : VRTK_InteractableObject {
	public Light light;
	public Collider col;

	public override void StartUsing(VRTK_InteractUse usingObject) {
		base.StartUsing(usingObject);
		light.enabled = true;
		col.enabled = false;
	}

	public override void StopUsing(VRTK_InteractUse usingObject) {
		base.StopUsing(usingObject);
		light.enabled = false;
		col.enabled = true;
	}
	
	void Update () {
		base.Update();
	}
}
