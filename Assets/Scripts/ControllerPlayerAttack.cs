using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ControllerPlayerID))]
public class ControllerPlayerAttack : MonoBehaviour {
	private ControllerPlayerID _id;
	private CharacterControllerImpactEnforcer _impactEnforcer;

	public float attackForce;
	public float upAttackForce;
	public float attackCooldown;
	public int attackDamage;

	private bool _canAttack = true;
	private bool _canCheckHit = false;
	private float _attackRange = 1.5f;

	private AnimationManager _animationManager;

	public LayerMask hitMask;

	void Start () {
		_id = GetComponent<ControllerPlayerID>();
		_impactEnforcer = GetComponent<CharacterControllerImpactEnforcer>();
		_animationManager = GetComponent<AnimationManager>();
	}
	
	void Update () {
		if (Input.GetButtonDown(_id.playerNumber + "_attack")) {
			if (_canAttack) Attack();
		}

		if (_canCheckHit) {
			RaycastHit hit;
			Vector3 origin = transform.position;
			origin.y += 1f;
			if (Physics.Raycast(origin, _id.skinTransform.forward, out hit, _attackRange, hitMask)) {
				Rigidbody rb = hit.transform.gameObject.GetComponent<PlayerSkinCommunicator>().rb;
				if (rb) rb.AddForce(_id.skinTransform.forward * attackForce * 1500f);
				PlayerHP hp = hit.transform.gameObject.GetComponent<PlayerHP>();
				hp.TakeDamage(attackDamage);
				_canCheckHit = false;
			}
		}
	}

	void Attack () {
		_canAttack = false;
		_canCheckHit = true;

		Vector3 attackDirection = _id.skinTransform.forward;
		attackDirection.y = upAttackForce;
		_impactEnforcer.AddImpact(attackDirection, attackForce);
		GetComponent<SoundsManager>().Attack();
		_animationManager.anim.SetTrigger("attack");

		StartCoroutine(AttackCooldown());
	}

	IEnumerator AttackCooldown () {
		yield return new WaitForSeconds(attackCooldown);
		_canAttack = true;
		_canCheckHit = false;
	}
}
