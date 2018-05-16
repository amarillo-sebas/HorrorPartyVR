using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour {
	public int currentHP = 100;
	private PlayerSkinAudioManager _playerAudio;

	public Slider sldHP;

	void Start () {
		_playerAudio = GetComponent<PlayerSkinAudioManager>();
	}

	void Update () {
		if (sldHP) sldHP.value = currentHP;
	}

	public void TakeDamage (int d) {
		currentHP -= d;
		if (currentHP <= 0) {
			//Die();
		} else {
			_playerAudio.Hurt();
		}
	}
}
