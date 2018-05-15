using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkinCommunicator : MonoBehaviour {
	public Rigidbody rb;
	public Transform cam;
	public Transform minimapDummy;

	void Update () {
		Quaternion newRot = Quaternion.identity;
		newRot.eulerAngles = new Vector3(0f, cam.rotation.eulerAngles.y, 0f);
		minimapDummy.rotation = newRot;
	}
}
