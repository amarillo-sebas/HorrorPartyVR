using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPlayerAnimationEvents : MonoBehaviour {
	public SoundsManager sm;
	public ControllerPlayerMovement mov;
	public ControllerPlayerAttack cpa;

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
	}
	public void EmoAttackEnd () {
		mov.canMove = true;
		//Debug.Log(mov.canMove);
	}

	public void Attack_StartCheck () {
		cpa.Attack_StartCheck();
	}
	public void Attack_EndCheck () {
		cpa.Attack_EndCheck();
	}
}
