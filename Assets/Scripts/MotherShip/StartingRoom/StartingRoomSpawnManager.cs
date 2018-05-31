using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingRoomSpawnManager : MonoBehaviour {
	public GameObject roomContents;
	public GameObject door;
	public bool spawnContents = false;

	void Start () {
		GameObject doorGO = Instantiate(door, transform.position, transform.rotation);
		doorGO.transform.parent = transform;
		if (spawnContents) {
			Instantiate(roomContents, transform.position, transform.rotation).transform.parent = transform;
			GetComponentInChildren<StartingRoomController>().myAnimator = doorGO.GetComponentInChildren<Animator>();
		}
	}
}
