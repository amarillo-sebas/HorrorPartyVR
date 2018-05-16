using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class SelfDestructObjectiveZonePlacer : MonoBehaviour {
	public GameObject objetiveZonePrefab;
	public int objectiveIndex;
	public SelfDestruct_Operator sdo;

	private VRTK_SnapDropZone _sdz;

	void Start () {
		GameObject oz = Instantiate(objetiveZonePrefab, transform.position, transform.rotation);
		oz.transform.parent = transform;

		_sdz = oz.GetComponent<VRTK_SnapDropZone>();
		_sdz.sdo = sdo;
		_sdz.objectiveIndex = objectiveIndex;
	}
}
