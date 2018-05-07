using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkinAudioManager : MonoBehaviour {
	public AudioClip[] hurtSounds;
	public AudioSource playerAudioSource;

	public void Hurt () {
		int r = Random.Range(0, hurtSounds.Length);
		playerAudioSource.clip = hurtSounds[r];
		float p = Random.Range(0.8f, 1.2f);
		playerAudioSource.pitch = p;
		playerAudioSource.PlayDelayed(0.25f);
	}
}
