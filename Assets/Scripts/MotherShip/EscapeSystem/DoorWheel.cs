using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK.UnityEventHelper;
using VRTK;

public class DoorWheel : MonoBehaviour {
	private VRTK_Control_UnityEvents controlEvents;
	public Transform doorTransform;
	public float moveAmount;
	public EscapeShipLever escapeShipLever;

	private float _doorStartPosition;
	private float _doorEndPosition;

	public enum doorAxisEnum {
		x,
		y,
		z
	}
	public doorAxisEnum doorAxis;

	void Start () {
		switch (doorAxis) {
			case doorAxisEnum.x:
				_doorStartPosition = doorTransform.localPosition.x;
			break;
			case doorAxisEnum.y:
				_doorStartPosition = doorTransform.localPosition.y;
			break;
			case doorAxisEnum.z:
				_doorStartPosition = doorTransform.localPosition.z;
			break;
		}
		_doorEndPosition = _doorStartPosition + moveAmount;
	}
	
	public void HandleChange (object sender, Control3DEventArgs e) {
		float v = e.value;
		float currentPosition = Remap(v, 0f, 1f, _doorStartPosition, _doorEndPosition);

		Vector3 newDoorPosition = doorTransform.localPosition;
		switch (doorAxis) {
			case doorAxisEnum.x:
				newDoorPosition.x = currentPosition;
			break;
			case doorAxisEnum.y:
				newDoorPosition.y = currentPosition;
			break;
			case doorAxisEnum.z:
				newDoorPosition.z = currentPosition;
			break;
		}

		doorTransform.localPosition = newDoorPosition;

		if (v >= 0.9f) {
			escapeShipLever.canBlastOff = true;
		} else {
			escapeShipLever.canBlastOff = false;
		}
	}

	public static float Remap (float value, float low1, float high1, float low2, float high2) {
		float r;
		r = low2 + (value - low1) * (high2 - low2) / (high1 - low1);
		return r;
	}

	public void BlastOff () {
		Destroy(GetComponent<HingeJoint>());
		Destroy(GetComponent<Rigidbody>());
		Destroy(GetComponent<Collider>());
	}
}
