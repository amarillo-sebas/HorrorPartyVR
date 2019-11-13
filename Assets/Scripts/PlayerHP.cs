using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using VRTK;

public class PlayerHP : MonoBehaviour {
	public int currentHP = 100;
	private int _maxHP;
	private PlayerSkinAudioManager _playerAudio;

	public Slider sldHP;

	public Animator cameraAnimator;
	public VRTK_ControllerEvents[] controllers;

	public Transform hpCanvas;

	public bool safeFromVacuum = false;

	public float regenTime;
	public float regenRate;
	private float _regenCooldown = 0f;
	private float _regenRateCounter = 0f;

	void Start () {
		_maxHP = currentHP;
		_playerAudio = GetComponent<PlayerSkinAudioManager>();
	}

	void Update () {
		if (sldHP) sldHP.value = currentHP;
		if (hpCanvas) hpCanvas.rotation = Quaternion.identity;

		if (currentHP < _maxHP) {
			if (_regenCooldown <= Time.time) {
				if (_regenRateCounter <= Time.time) {
					_regenRateCounter = Time.time + regenRate;
					currentHP++;
				}
			}
		}
	}

	public void TakeDamage (int d) {
		currentHP -= d;
		if (currentHP <= 0) {
			Die();
		} else {
			_playerAudio.Hurt();
			if (cameraAnimator) cameraAnimator.SetTrigger("HurtPlayer");
		}

		_regenCooldown = Time.time + regenTime;
	}

	void Die () {
		_playerAudio.Die();
		if (cameraAnimator) cameraAnimator.SetTrigger("KillPlayer");
		foreach (VRTK_ControllerEvents c in controllers) {
			c.enabled = false;
		}
		StartCoroutine(Restart());
	}

	IEnumerator Restart () {
		yield return new WaitForSeconds(5f);
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
