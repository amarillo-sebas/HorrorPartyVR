using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPlayerSkinSelector : MonoBehaviour {
	public GameObject[] skins;
	public MonsterType selectedSkin;
	public Transform mySkin;

	void Start () {
		mySkin = Instantiate(skins[(int)selectedSkin], transform.position, transform.rotation).transform;
		mySkin.parent = transform;
		mySkin.SetSiblingIndex(0);
	}
}
