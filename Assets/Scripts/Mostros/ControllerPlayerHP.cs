using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerPlayerHP : MonoBehaviour {
	public AnimationManager animationManager;
	private int _maxHP;
	public int currentHP = 100;
	public SoundsManager sm;

	public Slider sldHP;

	public GameObject psDeath;

	public bool isEgg = false;

	public bool isAlive = true;

	public int respawnTime;

	public RespawnText respawnText;

	public CharacterController cc;

	private AttackEffects _ae;

	IEnumerator Start () {
		sm = GetComponent<SoundsManager>();
		_maxHP = currentHP;

		yield return new WaitForSeconds(0.25f);
		_ae = GetComponentInChildren<AttackEffects>();
	}
	
	void Update () {
		if (sldHP) sldHP.value = currentHP;
	}

	public void TakeDamage (int d) {
		if (isAlive) {
			currentHP -= d;
			if (currentHP <= 0) {
				Die();
			} else {
				if (sm) sm.TakeDamage();
			}
		}
	}

	public void Die () {
		if (psDeath) {
			Destroy(Instantiate(psDeath, transform.position, transform.rotation), 5f);
		}
		if (isEgg) GetComponent<HatcherEgg>().EggDestroy();
		//Destroy(gameObject);
		animationManager.anim.SetTrigger("die");

		if (sm) sm.Die();
		isAlive = false;
		cc.enabled = false;
		if (respawnTime > 0) StartCoroutine(Respawn());
	}

	public void Heal (int h) {
		if (isAlive) {
			currentHP += h;
			if (currentHP >= _maxHP) currentHP = _maxHP;
		}	
	}

	IEnumerator Respawn () {
		respawnText.Engage(respawnTime);
		yield return new WaitForSeconds((int)respawnTime);
		if (_ae) _ae.PriestRespawn();
		isAlive = true;
		animationManager.anim.SetTrigger("respawn");
		currentHP = _maxHP;
		cc.enabled = true;
	}
}
