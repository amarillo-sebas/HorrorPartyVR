using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatcherEgg : MonoBehaviour {
	[Space(5f)]
	[Header("Dependencies")]
	public HatcherAttack hatcher;
	public GameObject popFX;
	public LayerMask layers;

	[Space(5f)]
	[Header("Variables")]
	public int damage;
	public float detectionDistance;
	public float detectionInterval;
	private float detectionCounter = 0f;

	private bool _destroyed = false;

	void Update () {
		if (detectionCounter < Time.time) {
			detectionCounter = Time.time + detectionInterval;
			Collider[] cols = Physics.OverlapSphere(transform.position, detectionDistance, layers);
			foreach (Collider c in cols) {
				PlayerHP hp = c.GetComponent<PlayerHP>();
				if (hp) {
					hp.TakeDamage(damage);
					EggDestroy();
				}
			}
		}
	}

	public void Abort () {
		Destroy(gameObject);
	}

	public void EggDestroy () {
		if (!_destroyed) {
			_destroyed = true;
			Destroy(Instantiate(popFX, transform.position, transform.rotation), 5f);
			if (hatcher) hatcher.RemoveEgg(this);
			Destroy(gameObject);
		}
	}
}
