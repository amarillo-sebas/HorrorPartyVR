using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmoAnimationEvents : MonoBehaviour {
	public ControllerPlayerAnimationEvents cpae;
	public ParticleSystem ps;

	public void EmoAttackStart () {
		cpae.EmoAttackStart();
	}
	public void EmoParticleStart () {
		ps.Play();
	}
	public void Attack_StartCheck() {
		cpae.Attack_StartCheck();
	}
	public void EmoAttackEnd () {
		cpae.EmoAttackEnd();
		cpae.Attack_EndCheck();
	}
}
