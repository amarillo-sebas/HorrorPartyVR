using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPlayerID : MonoBehaviour {
	public int playerNumber;
	public Transform skinTransform;
	private ControllerPlayerSkinSelector _cpss;

	void Start () {
		_cpss = GetComponent<ControllerPlayerSkinSelector>();
		if (!_cpss.mySkin) StartCoroutine(WaitForSkin());
		else if (!skinTransform) skinTransform = _cpss.mySkin;
	}

	IEnumerator WaitForSkin () {
		//Debug.Log("skin");
		yield return null;
		_cpss = GetComponent<ControllerPlayerSkinSelector>();
		if (!_cpss.mySkin) StartCoroutine(WaitForSkin());
		else  if (!skinTransform) skinTransform = _cpss.mySkin;
	}

	/*Transform LookForSkin () {
		Transform t = null;
		int children = transform.childCount;
		for (int i = 0; i < children; i++) {
			if (transform.GetChild(i).tag == "MonsterSkin") {
				t = transform.GetChild(i);
				return t;
			}
		}
		return t;
	}*/
}
