using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCloser : MonoBehaviour {
	public StartingRoomController startingRoomScript;
	public float timeToCloseDoor;

	public bool runningCoroutine = false;

	void OnTriggerExit (Collider c) {
		if (!runningCoroutine) if (c.transform.name == "[VRTK][AUTOGEN][HeadsetColliderContainer]") StartCoroutine(WaitToCloseDoor(timeToCloseDoor));
	}

	IEnumerator WaitToCloseDoor (float t) {
		runningCoroutine = true;
		yield return new WaitForSeconds(t);
		startingRoomScript.CloseDoor();
		runningCoroutine = false;
	}
}
