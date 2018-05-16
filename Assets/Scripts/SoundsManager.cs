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
	public AudioClip[] deathClips;

	public float speakMinTime;
	public float speakMaxTime;

	void Start () {
		StartCoroutine(Speak(1, 5));
	}
	
	IEnumerator Speak (float minT, float maxT) {
		float t = Random.Range(minT, maxT);
		yield return new WaitForSeconds(t);
		PlayClip(voiceAudioSource, voiceClips);
		/*int r = Random.Range(0, voiceClips.Length);
		voiceAudioSource.clip = voiceClips[r];
		voiceAudioSource.Play();*/
		StartCoroutine(Speak(speakMinTime, speakMaxTime));
	}

	public void Step () {
		PlayClip(stepsAudioSource, stepClips);
		/*int r = Random.Range(0, stepClips.Length);
		stepsAudioSource.clip = stepClips[r];
		stepsAudioSource.Play();*/
	}

	public void Attack () {
		PlayClip(voiceAudioSource, attackClips, 0.7f, 1f);
		/*int r = Random.Range(0, attackClips.Length);
		voiceAudioSource.clip = attackClips[r];
		float p = Random.Range(0.7f, 1f);
		voiceAudioSource.pitch = p;
		voiceAudioSource.Play();*/
	}

	public void TakeDamage () {
		PlayClip(voiceAudioSource, damageClips, 0.85f, 1f);
		/*if (damageClips.Length > 0) {
			int r = Random.Range(0, damageClips.Length);
			voiceAudioSource.clip = damageClips[r];
			float p = Random.Range(0.85f, 1f);
			voiceAudioSource.pitch = p;
			voiceAudioSource.Play();
		}*/
	}

	public void Die () {
		PlayClip(voiceAudioSource, deathClips, 0.85f, 1f);
		/*if (deathClips.Length > 0) {
			int r = Random.Range(0, deathClips.Length);
			voiceAudioSource.clip = deathClips[r];
			float p = Random.Range(0.85f, 1f);
			voiceAudioSource.pitch = p;
			voiceAudioSource.Play();
		}*/
	}

	public void PlayClip (AudioSource a, AudioClip[] ac) {
		if (ac.Length > 0 && !a.isPlaying) {
			int r = Random.Range(0, ac.Length);
			a.clip = ac[r];
			a.Play();
		}
	}
	public void PlayClip (AudioSource a, AudioClip[] ac, float min, float max) {
		if (ac.Length > 0 && !a.isPlaying) {
			int r = Random.Range(0, ac.Length);
			a.clip = ac[r];
			float p = Random.Range(min, max);
			a.pitch = p;
			a.Play();
		}
	}
}
