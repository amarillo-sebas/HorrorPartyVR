using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriestAttack : MonoBehaviour {
	[Space(5f)]
	[Header("Dependencies")]
	public Animator particleAnimator;
	public Animator lightAnimator;
	public PriestTrigger trigger;
	public ParticleSystem ps;

	public void Attack () {
		particleAnimator.SetTrigger("animate");
		lightAnimator.SetTrigger("animate");
		ps.Play();
		StartCoroutine(ActivateTrigger());
	}

	IEnumerator ActivateTrigger () {
		yield return new WaitForSeconds(1f);
		trigger.Enable();
		yield return new WaitForSeconds(3f);
		trigger.Disable();
	}
}
