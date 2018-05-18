using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirlocksManager : MonoBehaviour {
	public GameObject[] escapeAirlocks;

	public void PrepareEscape (int i) {
		escapeAirlocks[i].SetActive(true);
	}
}
