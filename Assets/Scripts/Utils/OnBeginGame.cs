using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBeginGame : MonoBehaviour {
	private HideLightsFromCamera _monsterCameraScript;
	public Light flashlight;

	void Start () {
		_monsterCameraScript = GameObject.FindWithTag("MonsterCamera").GetComponent<HideLightsFromCamera>();
		StartCoroutine(WaitForFlashlight());
	}

	public void BeginGameEvent () {
		_monsterCameraScript.Lights.Remove(flashlight);
	}
	
	void OnTriggerExit (Collider c) {
		if (c.tag == "BeginGameTrigger") {
			Debug.Log("poop");
			
		}
	}

	IEnumerator WaitForFlashlight () {
		yield return null;
		yield return null;
		flashlight = GetComponentInChildren<Light>();
		_monsterCameraScript.Lights.Add(flashlight);
	}
}
