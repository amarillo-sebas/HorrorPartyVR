using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerPlayerHP : MonoBehaviour {
	//public int maxHP = 100;
	public int currentHP = 100;
	public SoundsManager sm;

	public Slider sldHP;

	public GameObject psDeath;

	void Start () {
		sm = GetComponent<SoundsManager>();
	}
	
	void Update () {
		if (sldHP) sldHP.value = currentHP;
	}

	public void TakeDamage (int d) {
		currentHP -= d;
		if (currentHP <= 0) {
			Die();
		} else {
			sm.TakeDamage();
		}
	}

	public void Die () {
		if (psDeath) {
			Destroy(Instantiate(psDeath, transform.position, transform.rotation), 5f);
		}
		Destroy(gameObject);
	}

	/*void OnParticleCollision(GameObject ps) {
		InteractableFlameThrower ift = ps.transform.parent.GetComponent<InteractableFlameThrower>();

		TakeDamage();
	}*/

}
