using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShipMissionManager : MonoBehaviour {
	public MotherShipAudioManager audioManager;
	public bool displayObjectiveLocations = false;
	public int selfDestructSeconds;
	public GameObject[] world;
	public GameObject destructionDebris;
	public GameObject explosionsPrefab;
	
	public void StartMission () {
		displayObjectiveLocations = true;
		audioManager.StartMission();
	}

	public void StartSelfDestructCountdown () {
		StartCoroutine(SelfDestructCountdown(4f));
		audioManager.StartSelfDestructCountdown();
	}
	IEnumerator SelfDestructCountdown (float t) {
		yield return new WaitForSeconds(t);
		if (selfDestructSeconds >= 0) audioManager.PlayClip(audioManager.selfDestructCountdownClips[selfDestructSeconds]);
		selfDestructSeconds--;

		if (selfDestructSeconds < -1) {
			SelfDestruct();
		} else {
			StartCoroutine(SelfDestructCountdown(2f));
		}
	}

	public void SelfDestruct () {
		audioManager.EndCountdown();
		StartCoroutine(WaitToSelfDestruct());
	}
	IEnumerator WaitToSelfDestruct () {
		yield return new WaitForSeconds(3f);
		Physics.gravity = Vector3.zero;
		Instantiate(explosionsPrefab);
		yield return new WaitForSeconds(0.25f);
		foreach (GameObject go in world) {
			go.SetActive(false);
		}
		destructionDebris.SetActive(true);
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.P)) {
			SelfDestruct();
		}
		if (Input.GetKeyDown(KeyCode.O)) {
			StartSelfDestructCountdown();
		}
	}
}
