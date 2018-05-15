using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : MonoBehaviour {
	public AudioClip[] voiceClips;
	public AudioClip[] attackClips;
	public AudioSource voiceAudioSource;
	public AudioClip[] stepClips;
	public AudioSource stepsAudioSource;
	public AudioClip[] damageClips;

	public float speakMinTime;
	public float speakMaxTime;

	void Start () {
		StartCoroutine(Speak(1, 5));
	}
	
	IEnumerator Speak (float min, float max) {
		float t = Random.Range(min, max);
		yield return new WaitForSeconds(t);
		int r = Random.Range(0, voiceClips.Length);
		voiceAudioSource.clip = voiceClips[r];
		voiceAudioSource.Play();
		StartCoroutine(Speak(speakMinTime, speakMaxTime));
	}

	public void Step () {
		int r = Random.Range(0, stepClips.Length);
		stepsAudioSource.clip = stepClips[r];
		stepsAudioSource.Play();
	}

	public void Attack () {
		int r = Random.Range(0, attackClips.Length);
		voiceAudioSource.clip = attackClips[r];
		float p = Random.Range(0.7f, 1f);
		voiceAudioSource.pitch = p;
		voiceAudioSource.Play();
	}

	public void TakeDamage () {
		if (damageClips.Length > 0) {
			int r = Random.Range(0, damageClips.Length);
			voiceAudioSource.clip = damageClips[r];
			float p = Random.Range(0.85f, 1f);
			voiceAudioSource.pitch = p;
			voiceAudioSource.Play();
		}
	}
}
