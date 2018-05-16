using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionObjectSpawner : MonoBehaviour {
	public GameObject importantObject;
	public GameObject[] secondaryObjects;
	public GameObject[] optionalObjects;
	public Transform[] importantObjectSpawns;
	public Transform[] secondaryObjectSpawns;
	public Transform[] optionalObjectSpawns;
	private int[] _randomSecondarySpawns;
	private int[] _randomOptionalSpawns;

	void Start () {
		int iR = Random.Range(0, importantObjectSpawns.Length);
		GameObject important = Instantiate(importantObject, importantObjectSpawns[iR].position, importantObjectSpawns[iR].rotation);
		important.transform.parent = transform;

		_randomSecondarySpawns = new int[secondaryObjectSpawns.Length];
		for (int i = 0; i < _randomSecondarySpawns.Length; i++) {
			_randomSecondarySpawns[i] = i;
		}
		_randomSecondarySpawns = ShuffleArray(_randomSecondarySpawns);
		for (int i = 0; i < secondaryObjects.Length; i++) {
			Instantiate(secondaryObjects[i], secondaryObjectSpawns[_randomSecondarySpawns[i]].position, secondaryObjectSpawns[_randomSecondarySpawns[i]].rotation);
		}
		
		_randomOptionalSpawns = new int[optionalObjectSpawns.Length];
		for (int i = 0; i < _randomOptionalSpawns.Length; i++) {
			_randomOptionalSpawns[i] = i;
		}
		_randomOptionalSpawns = ShuffleArray(_randomOptionalSpawns);
		for (int i = 0; i < optionalObjects.Length; i++) {
			Instantiate(optionalObjects[i], optionalObjectSpawns[_randomOptionalSpawns[i]].position, optionalObjectSpawns[_randomOptionalSpawns[i]].rotation);
		}

		//Destroy(gameObject);
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
