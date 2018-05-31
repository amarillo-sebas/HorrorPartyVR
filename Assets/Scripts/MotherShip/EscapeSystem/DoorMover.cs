using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMover : MonoBehaviour {
	private float _doorStartPosition;
	private float _doorEndPosition;
	public float moveAmount;

	void Start () {
		_doorStartPosition = transform.localPosition.z;
		_doorEndPosition = _doorStartPosition + moveAmount;
	}

	public void MoveDoor (float v) {
		float newPosition = Remap(v, 0f, 1f, _doorStartPosition, _doorEndPosition);
		Debug.Log(newPosition);
	}

	public static float Remap (float value, float low1, float high1, float low2, float high2) {
		float r;
		r = low2 + (value - low1) * (high2 - low2) / (high1 - low1);
		return r;
	}
}
