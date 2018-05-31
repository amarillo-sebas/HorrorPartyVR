using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTriggerEventsToPlayerColllider : MonoBehaviour {
	public GameObject guiltyChild;

	void Start () {
		StartCoroutine(WaitForCollider());
	}
	
	IEnumerator WaitForCollider () {
		yield return null;
		yield return null;
		yield return null;
		yield return null;
		yield return null;
		guiltyChild = transform.GetChild(3).gameObject;
		guiltyChild.AddComponent<PlayerTiggerEvents>();
	}
}
