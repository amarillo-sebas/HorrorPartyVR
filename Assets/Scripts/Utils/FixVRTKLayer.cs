using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixVRTKLayer : MonoBehaviour {
	public string layerName;
	public GameObject guiltyChild;
	private Transform[] theChildren;

	void Start () {
		StartCoroutine(FixLayerTimer());
		theChildren = GetComponentsInChildren<Transform>();
	}

	IEnumerator FixLayerTimer () {
		yield return null;
		yield return null;
		yield return null;
		yield return null;
		yield return null;
		guiltyChild = transform.GetChild(3).gameObject;
		guiltyChild.layer = LayerMask.NameToLayer(layerName);
		foreach (Transform c in theChildren) {
			c.gameObject.layer = LayerMask.NameToLayer(layerName);
		}
	}
}
