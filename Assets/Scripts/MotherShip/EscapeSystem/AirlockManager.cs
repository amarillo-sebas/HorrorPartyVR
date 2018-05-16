using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AirlockManager : MonoBehaviour {
	public Animator doorAnim;
	public AudioSource audioS;

	public bool[] buttonsStates;
	private bool _canOpen = false;

	public AudioClip[] clips;

	public void Start () {
		for (int i = 0; i < buttonsStates.Length; i++) {
			int r = Random.Range(0, 2);
			bool b;
			if (r == 0) {
				b = false;
			} else {
				b = true;
			}
			buttonsStates[i] = b;
		}
	}

	public void OpenDoor () {
		StartCoroutine(OpenDoorTimer(0.5f));
	}
	IEnumerator OpenDoorTimer (float t) {
		audioS.clip = clips[1];
		audioS.Play();
		yield return new WaitForSeconds(t);
		audioS.clip = clips[2];
		audioS.Play();
		doorAnim.SetBool("Open", true);
	}
	public void CloseDoor () {
		StartCoroutine(CloseDoorTimer(0.5f));
	}
	IEnumerator CloseDoorTimer (float t) {
		yield return new WaitForSeconds(t);
		doorAnim.SetBool("Open", false);
	}

	public void ChangeButtonState(bool s, int i) {
		buttonsStates[i] = s;
		_canOpen = true;
		audioS.clip = clips[0];
		audioS.Play();
		foreach (bool co in buttonsStates) {
			if (!co) {
				_canOpen = false;
			}
		}
		if (_canOpen) {
			OpenDoor();
		}
	}
}
