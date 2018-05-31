using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionObjectSpawner : MonoBehaviour {
	public GameObject importantObject;
	public GameObject[] secondaryObjects;
	public GameObject[] optionalObjects;
	public GameObject startingRoom;
	public GameObject[] importantObjectSpawns;
	public GameObject[] secondaryObjectSpawns;
	public GameObject[] pickUpObjectSpawns;
	public GameObject[] startingRoomsSpawns;
	private int[] _randomSecondarySpawns;
	private int[] _randomOptionalSpawns;

	public bool spawnBothInSecondary = false;

	public GameObject playerPrefab;
	private GameObject[] _playerSpawns;

	void Start () {
		importantObjectSpawns = GameObject.FindGameObjectsWithTag("ImportantObjectSpawner");
		secondaryObjectSpawns = GameObject.FindGameObjectsWithTag("SecondaryObjectSpawner");
		pickUpObjectSpawns = GameObject.FindGameObjectsWithTag("PickUpObjects");

		int srR = Random.Range(0, startingRoomsSpawns.Length);
		for (int sr = 0; sr < startingRoomsSpawns.Length; sr++) {
			GameObject room = Instantiate(startingRoom, startingRoomsSpawns[sr].transform.position, startingRoomsSpawns[sr].transform.rotation);
			room.transform.parent = transform;
			if (sr == srR) {
				room.GetComponent<StartingRoomSpawnManager>().spawnContents = true;
			}
		}

		int iR = Random.Range(0, importantObjectSpawns.Length);
		GameObject important = Instantiate(importantObject, importantObjectSpawns[iR].transform.position, importantObjectSpawns[iR].transform.rotation);
		important.transform.parent = transform;

		if (!spawnBothInSecondary) {
			_randomSecondarySpawns = new int[secondaryObjectSpawns.Length];
			for (int i = 0; i < _randomSecondarySpawns.Length; i++) {
				_randomSecondarySpawns[i] = i;
			}
			_randomSecondarySpawns = ShuffleArray(_randomSecondarySpawns);
			for (int i = 0; i < secondaryObjects.Length; i++) {
				Instantiate(secondaryObjects[i], secondaryObjectSpawns[_randomSecondarySpawns[i]].transform.position, secondaryObjectSpawns[_randomSecondarySpawns[i]].transform.rotation).transform.parent = transform;;
			}
			
			_randomOptionalSpawns = new int[pickUpObjectSpawns.Length];
			for (int i = 0; i < _randomOptionalSpawns.Length; i++) {
				_randomOptionalSpawns[i] = i;
			}
			_randomOptionalSpawns = ShuffleArray(_randomOptionalSpawns);
			for (int i = 0; i < optionalObjects.Length; i++) {
				Instantiate(optionalObjects[i], pickUpObjectSpawns[_randomOptionalSpawns[i]].transform.position, pickUpObjectSpawns[_randomOptionalSpawns[i]].transform.rotation).transform.parent = transform;;
			}
		} else {
			_randomSecondarySpawns = new int[secondaryObjectSpawns.Length];
			for (int i = 0; i < _randomSecondarySpawns.Length; i++) {
				_randomSecondarySpawns[i] = i;
			}
			_randomSecondarySpawns = ShuffleArray(_randomSecondarySpawns);
			for (int i = 0; i < secondaryObjects.Length + optionalObjects.Length; i++) {
				if (i < secondaryObjects.Length) {
					Instantiate(secondaryObjects[i], secondaryObjectSpawns[_randomSecondarySpawns[i]].transform.position, secondaryObjectSpawns[_randomSecondarySpawns[i]].transform.rotation).transform.parent = transform;;
				} else {
				 	Instantiate(optionalObjects[i - secondaryObjects.Length], secondaryObjectSpawns[_randomSecondarySpawns[i]].transform.position, secondaryObjectSpawns[_randomSecondarySpawns[i]].transform.rotation).transform.parent = transform;;
				}
			}
		}
		
		//important.transform.parent = transform;

		StartCoroutine(SpawnPlayer());

		//Destroy(gameObject);
	}

	IEnumerator SpawnPlayer () {
		yield return null;
		_playerSpawns = GameObject.FindGameObjectsWithTag("PlayerSpawn");
		int pR = Random.Range(0, _playerSpawns.Length);
		//Debug.Log(_playerSpawns.Length + " caca " + pR);
		playerPrefab.transform.position = _playerSpawns[pR].transform.position;
	}

	int[] ShuffleArray(int[] array) {
		for (int i = array.Length; i > 0; i--) {
			int j = Random.Range(0, i);
			int k = array[j];
			array[j] = array[i - 1];
			array[i - 1]  = k;
		}
		return array;
	}
}
