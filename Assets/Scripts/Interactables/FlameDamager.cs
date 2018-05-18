using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameDamager : MonoBehaviour {
	public ParticleSystem ps;
	public List<ParticleCollisionEvent> collisionEvents;
	public InteractableFlameThrower ift;

	private float counter = 0f;
	int canDamage = 0;

	void Start () {
		collisionEvents = new List<ParticleCollisionEvent>();
	}
	
	void Update () {
		if (Time.time >= counter) {
			canDamage = 1;
			counter = Time.time + ift.damageRate;
		} else {
			canDamage = 0;
		}
	}

	void OnParticleCollision (GameObject go) {
		int numCollisionEvents = ps.GetCollisionEvents(go, collisionEvents);

		ControllerPlayerHP mostro = go.GetComponent<ControllerPlayerHP>();
		int i = 0;
		while (i < numCollisionEvents) {
			if (mostro) {
				//Debug.Log("mostro");
				mostro.TakeDamage(ift.damage * canDamage);
			}
			i++;
		}
	}
}
