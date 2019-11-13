using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCloser : MonoBehaviour {
	public StartingRoomController startingRoomScript;
	public float timeToCloseDoor;

	public bool runningCoroutine = false;

	void OnTriggerExit (Collider c) {
		//[VRTK][AUTOGEN][HeadsetColliderContainer]
		if (!runningCoroutine) if (c.transform.name == "[VRTK][AUTOGEN][BodyColliderContainer]") {
			StartCoroutine(WaitToCloseDoor(timeToCloseDoor));
			c.GetComponent<PlayerTiggerEvents>().TriggerEvent();
		}
	}

	IEnumerator WaitToCloseDoor (float t) {
		runningCoroutine = true;
		yield return new WaitForSeconds(t);
		startingRoomScript.CloseDoor();
		runningCoroutine = false;
		MotherShipAudioManager msam = FindObjectOfType(typeof(MotherShipAudioManager)) as MotherShipAudioManager;
		if (msam) msam.PlayLifeForms();
	}
}
