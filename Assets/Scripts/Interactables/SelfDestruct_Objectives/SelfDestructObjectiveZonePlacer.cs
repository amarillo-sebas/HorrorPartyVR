using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructObjectiveZonePlacer : MonoBehaviour {
	public GameObject objetiveZonePrefab;

	void Start () {
		GameObject oz = Instantiate(objetiveZonePrefab, transform.position, transform.rotation);
		oz.transform.parent = transform;
	}
}
