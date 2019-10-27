using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerPlayerHP : MonoBehaviour {
	private int _maxHP;
	public int currentHP = 100;
	public SoundsManager sm;

	public Slider sldHP;

	public GameObject psDeath;

	public bool isEgg = false;
	void Start () {
		sm = GetComponent<SoundsManager>();
		_maxHP = currentHP;
	}
	
	void Update () {
		if (sldHP) sldHP.value = currentHP;
	}

	public void TakeDamage (int d) {
		currentHP -= d;
		if (currentHP <= 0) {
			Die();
		} else {
			if (sm) sm.TakeDamage();
		}
	}

	public void Die () {
		if (psDeath) {
			Destroy(Instantiate(psDeath, transform.position, transform.rotation), 5f);
		}
		if (isEgg) GetComponent<HatcherEgg>().EggDestroy();
		Destroy(gameObject);
	}

	public void Heal (int h) {
		currentHP += h;
		if (currentHP >= _maxHP) currentHP = _maxHP;
	}

	/*void OnParticleCollision(GameObject ps) {
		InteractableFlameThrower ift = ps.transform.parent.GetComponent<InteractableFlameThrower>();

		TakeDamage();
	}*/

}
