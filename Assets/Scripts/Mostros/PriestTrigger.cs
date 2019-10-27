using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriestTrigger : MonoBehaviour {
	[Space(5f)]
	[Header("Dependencies")]
	public LayerMask layers;

	[Space(5f)]
	[Header("Variables")]
	public int monsterHeal;
	public int playerDamage;

	private float _interval = 0.9f;
	private float _counter = 0f;
	private bool _canAffect = false;

	void Update () {
		if (_canAffect) {
			if (_counter < Time.time) {
				_counter = Time.time + _interval;
				Collider[] cols = Physics.OverlapSphere(transform.position, 2.5f, layers);
				foreach (Collider c in cols) {
					PlayerHP hp = c.GetComponent<PlayerHP>();
					ControllerPlayerHP chp = c.GetComponent<ControllerPlayerHP>();
					if (hp) hp.TakeDamage((int)(playerDamage / 3f));
					else if (chp) chp.Heal((int)(monsterHeal / 3f));
				}
			}
		}
	}

	public void Enable () {
		_canAffect = true;
	}
	public void Disable () {
		_canAffect = false;
		_counter = 0f;
	}
}
