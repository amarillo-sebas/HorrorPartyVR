using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPlayerAnimationEvents : MonoBehaviour {
	public SoundsManager sm;
	public void StepSound () {
		sm.Step();
	}
}
