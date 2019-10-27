using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPlayerAnimationEvents : MonoBehaviour {
	public SoundsManager sm;
	public ControllerPlayerMovement mov;
	public ControllerPlayerAttack cpa;
	public AttackEffects attackEffects;

	void Start () {
		if (!sm) sm = transform.parent.GetComponent<SoundsManager>();
		mov = transform.parent.GetComponent<ControllerPlayerMovement>();
		cpa = transform.parent.GetComponent<ControllerPlayerAttack>();
	}

	public void StepSound () {
		sm.Step();
	}

	public void EmoAttackStart () {
		mov.canMove = false;
		if (attackEffects) attackEffects.Attack();

	}
	public void EmoAttackEnd () {
		mov.canMove = true;
		//Debug.Log(mov.canMove);
	}

	public void PriestAttack () {
		mov.canMove = false;
		if (attackEffects) attackEffects.Attack();
		StartCoroutine(PriestAttackCounter());
		cpa.StartAttack();
	}

	public void HatcherAttack () {
		mov.canMove = false;
	}
	public void HatcherEgg () {
		if (attackEffects) attackEffects.Attack();
	}
	public void HatcherAttackEnd () {
		mov.canMove = true;
	}

	public void Attack_StartCheck () {
		cpa.Attack_StartCheck();
	}
	public void Attack_EndCheck () {
		cpa.Attack_EndCheck();
	}

	IEnumerator PriestAttackCounter () {
		yield return new WaitForSeconds(5f);
		mov.canMove = true;
		cpa.EndAttack();
	}
}
