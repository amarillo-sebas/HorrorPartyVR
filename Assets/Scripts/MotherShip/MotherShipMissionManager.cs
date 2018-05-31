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

	public AirlocksManager airlocks;
	public EscapeShipsManager escapeShips;
	
	public void Start () {
		Cursor.visible = false;
	}

	public void StartMission () {
		displayObjectiveLocations = true;
		audioManager.StartMission();
	}

	public void StartSelfDestructCountdown () {
		int r = Random.Range(0, airlocks.escapeAirlocks.Length);
		airlocks.PrepareEscape(r);
		escapeShips.PrepareEscape(r);

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
		//Physics.gravity = Vector3.zero;
		Instantiate(explosionsPrefab);
		yield return new WaitForSeconds(0.25f);

		pHP = FindObjectOfType(typeof(PlayerHP)) as PlayerHP;
		mHP = FindObjectsOfType(typeof(ControllerPlayerHP)) as ControllerPlayerHP[];
		StartCoroutine(HurtPlayers(1f));

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

	private PlayerHP pHP;
	private ControllerPlayerHP[] mHP;
	IEnumerator HurtPlayers (float t) {
		if (pHP) if (pHP.currentHP > 0 && !pHP.safeFromVacuum) pHP.TakeDamage(10);
		foreach (ControllerPlayerHP mostroHP in mHP) {
			if (mostroHP) if (mostroHP.currentHP > 0) mostroHP.TakeDamage(10);
		}
		yield return new WaitForSeconds(t);
		StartCoroutine(HurtPlayers(t));
	}
}
