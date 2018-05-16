using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MotherShipAudioManager : MonoBehaviour {
	public AudioSource audioS;
	public AudioClip[] missionStartClips;
	public AudioClip[] selfDestructClips;
	public AudioClip[] selfDestructCountdownClips;
	public AudioClip[] thankClips;

	public void StartMission () {
		PlayClip(missionStartClips);
	}

	public void StartSelfDestructCountdown () {
		PlayClip(selfDestructClips);
	}

	public void EndCountdown () {
		PlayClip(thankClips);
	}

	public void PlayClip (AudioClip ac) {
		if (ac) {
			audioS.clip = ac;
			audioS.Play();
		}
	}
	public void PlayClip (AudioClip[] ac) {
		if (ac.Length > 0) {
			int r = Random.Range(0, ac.Length);
			audioS.clip = ac[r];
			//float p = Random.Range(0.85f, 1f);
			//audioS.pitch = p;
			audioS.Play();
		}
	}
}
