﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using VRTK;
using TMPro;

public class InteractableFlameThrower : VRTK_InteractableObject {
	public ParticleSystem ps;
	public ParticleSystem light;
	public Collider col;

	public TextMeshProUGUI txtAmmo;

	private bool _firing = false;

	public int ammo;
	public int maxAmmo;
	private float counter = 0f;
	public float fireRate = 0.2f;
	public float ammoRecoveryRate;
	private float ammoRecoveryCounter = 0f;

	public AudioSource audioS;
	public AudioClip[] clips;

	private bool _canFire;

	public int damage = 1;
	public float damageRate = 0.1f;

	public override void StartUsing(VRTK_InteractUse usingObject) {
		base.StartUsing(usingObject);
		if (ammo > 5) {
			//ps.Play();
			//if (light) light.Play();
			//_firing = true;
			audioS.clip = clips[0];
			audioS.Play();
			_canFire = true;
		}
	}

	public override void StopUsing(VRTK_InteractUse usingObject) {
		base.StopUsing(usingObject);
		//ps.Stop();
		//if (light) light.Stop();
		//_firing = false;
		//audioS.Stop();
		_canFire = false;
	}

	void Update () {
		base.Update();

		int ammoSpent = 0;

		if (_firing && ammo > 0) {
			if (Time.time >= counter) {
				ammoSpent--;
				counter = Time.time + fireRate;
			}
		}

		if (Time.time >= ammoRecoveryCounter && ammo <= maxAmmo) {
			ammoSpent++;
			ammoRecoveryCounter = Time.time + ammoRecoveryRate;
		}

		ammo += ammoSpent;

		if (ammo <= 0) {
			ammo = 0;

			_canFire = false;
			//audioS.clip = clips[1];
			//ps.Stop();
			//if (light) light.Stop();
		} else if (ammo > 100) {
			ammo = 100;
		}

		txtAmmo.text = ammo + "";

		if (_canFire) {
			ps.Play();
			if (light) light.Play();
			_firing = true;
			//audioS.Play();
		} else {
			ps.Stop();
			if (light) light.Stop();
			_firing = false;
			audioS.Stop();
		}
	}
}
