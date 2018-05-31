using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class StartingRoomAudio : AudioManager {
	public AudioSource audioSource;
	public AudioClip doorClip;
	public AudioClip button;

	public void Door () {
		PlayClip(audioSource, doorClip);
	}

	public void Button () {
		PlayClip(audioSource, button);
	}
}
