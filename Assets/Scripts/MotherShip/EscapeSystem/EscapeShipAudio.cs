using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class EscapeShipAudio : AudioManager {
	public AudioSource audioSource;
	public AudioClip blastOffClip;
	public AudioClip errorOffClip;

	public void Error () {
		PlayClip(audioSource, errorOffClip);
	}
	
	public void BlastOff () {
		PlayClip(audioSource, blastOffClip);
	}
}
