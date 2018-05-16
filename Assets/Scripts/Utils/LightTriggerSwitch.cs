using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTriggerSwitch : MonoBehaviour {
	public SelfDestruct_Operator sdo;
	private bool missionStarted = false;

	/*void OnTriggerEnter (Collider c) {
		if (c.tag == "Light") {
			c.gameObject.transform.GetChild(0).gameObject.SetActive(!c.gameObject.transform.GetChild(0).gameObject.activeSelf);
		}
	}*/

	void OnTriggerStay (Collider c) {
		if (c.tag == "Light") {
			if (!c.gameObject.transform.GetChild(0).gameObject.activeSelf) {
				c.gameObject.transform.GetChild(0).gameObject.SetActive(true);
			}
			
			if (!missionStarted) {
				sdo.StartMission();
				missionStarted = true;
			}
		}
	}
	void OnTriggerExit (Collider c) {
		if (c.tag == "Light") {
			c.gameObject.transform.GetChild(0).gameObject.SetActive(false);
		}
	}
}
