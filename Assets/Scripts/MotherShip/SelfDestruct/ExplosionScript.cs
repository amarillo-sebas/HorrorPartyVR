using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour {
	public float explosionForce = 4;
	private IEnumerator Start() {
		yield return null;

		float r = 30f;
		var cols = Physics.OverlapSphere(transform.position, r);

		var rigidbodies = new List<Rigidbody>();
		foreach (var col in cols) {
			if (col.attachedRigidbody != null && !rigidbodies.Contains(col.attachedRigidbody)) {
				rigidbodies.Add(col.attachedRigidbody);
			}
		}
		foreach (var rb in rigidbodies) {
			rb.AddExplosionForce(explosionForce, transform.position, r, 1, ForceMode.Impulse);
		}

		var impactEnforcers = new List<CharacterControllerImpactEnforcer>();
		foreach (var col in cols) {
			CharacterControllerImpactEnforcer tempEnforcer = col.transform.GetComponent<CharacterControllerImpactEnforcer>();
			if (tempEnforcer != null && !impactEnforcers.Contains(tempEnforcer)) {
				impactEnforcers.Add(tempEnforcer);
			}
		}
		foreach (var ie in impactEnforcers) {
			Vector3 dir = ie.transform.position - transform.position;
			ie.AddImpact(dir, explosionForce * 10f);
		}
	}
}
