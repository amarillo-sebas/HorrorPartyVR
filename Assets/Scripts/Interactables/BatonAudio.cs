using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BatonAudio : AudioManager {
	[Space(5f)]
	[Header("Dependencies")]
	public AudioSource audioSource;

	[Space(5f)]
	[Header("Variables")]
	public AudioClip[] openClips;
	public AudioClip[] closeClips;
	public AudioClip[] moveClips;
	public AudioClip[] hitClips;

	public void PlayOpen () {
		PlayClip(audioSource, openClips);
	}

	public void PlayClose () {
		PlayClipAlways(audioSource, closeClips);
	}

	public void PlayMove () {
		PlayClip(audioSource, moveClips);
	}

	public void PlayHit () {
		PlayClipAlways(audioSource, hitClips);
	}
}
