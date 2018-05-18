using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeShipsManager : MonoBehaviour {
	public GameObject[] escapeShips;

	public void PrepareEscape (int i) {
		escapeShips[i].SetActive(true);
	}
}
