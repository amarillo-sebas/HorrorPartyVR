using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerManager : MonoBehaviour {
	public static PlayerManager playerManager;

	public int numberOfPlayers;

	//==Singleton code==//
	void Awake () {
		if (playerManager == null) {
			DontDestroyOnLoad(gameObject);
			playerManager = this;
		}
		else if (playerManager != this) Destroy(gameObject);
	}

	void Start () {
		Cursor.visible = false;
	}
}
