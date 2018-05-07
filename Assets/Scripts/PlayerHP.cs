using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour {
	public int currentHP = 100;
	private PlayerSkinAudioManager _playerAudio;

	void Start () {
		_playerAudio = GetComponent<PlayerSkinAudioManager>();
	}

	public void TakeDamage (int d) {
		currentHP -= d;
		_playerAudio.Hurt();
	}
}
