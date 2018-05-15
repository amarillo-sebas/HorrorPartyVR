using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTriggerSwitch : MonoBehaviour {

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
		}
	}
	void OnTriggerExit (Collider c) {
		if (c.tag == "Light") {
			c.gameObject.transform.GetChild(0).gameObject.SetActive(false);
		}
	}
}
