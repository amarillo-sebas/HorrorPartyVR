using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkinCommunicator : MonoBehaviour {
	public Rigidbody rb;
	public Transform cam;

	public bool updateRotation = true;
	//public Transform minimapDummy;

	void Update () {
		if (updateRotation) {
			Quaternion newRot = Quaternion.identity;
			newRot.eulerAngles = new Vector3(0f, cam.rotation.eulerAngles.y, 0f);
			transform.rotation = newRot;
		}
	}
}
