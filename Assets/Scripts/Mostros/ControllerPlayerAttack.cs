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

	private bool _canAttack = false;
	private bool _canCheckHit = false;
	public float attackRange = 1.5f;

	private AnimationManager _animationManager;

	public LayerMask hitMask;

	public MonsterType EnemyType;

	public ControllerPlayerHP hp;

	void Start () {
		_id = GetComponent<ControllerPlayerID>();
		_impactEnforcer = GetComponent<CharacterControllerImpactEnforcer>();
		_animationManager = GetComponent<AnimationManager>();

		StartCoroutine(GameStart());
	}
	
	void Update () {
		if (hp.isAlive) {
			if (Input.GetButtonDown(_id.playerNumber + "_attack")) {
				if (_canAttack) {
					switch (EnemyType) {
						case MonsterType.Drone:
							Attack_DRONE();
						break;
						case MonsterType.Brain:
							Attack_BRAIN();
						break;
						case MonsterType.Priest:
							Attack_PRIEST();
						break;
						case MonsterType.Hatcher:
							Attack_HATCHER();
						break;
					}
				}
			}

			if (_canCheckHit) {
				RaycastHit hit;
				Vector3 origin = transform.position;
				origin.y += 1f;
				if (Physics.Raycast(origin, _id.skinTransform.forward, out hit, attackRange, hitMask)) {
					Rigidbody rb = hit.transform.gameObject.GetComponent<PlayerSkinCommunicator>().rb;
					if (rb) rb.AddForce(_id.skinTransform.forward * attackForce * 1500f);
					PlayerHP hp = hit.transform.gameObject.GetComponent<PlayerHP>();
					hp.TakeDamage(attackDamage);
					_canCheckHit = false;
				}
			}
		}
	}

	void Attack_DRONE () {
		_canAttack = false;
		_canCheckHit = true;

		Vector3 attackDirection = _id.skinTransform.forward;
		attackDirection.y = upAttackForce;
		_impactEnforcer.AddImpact(attackDirection, attackForce);
		GetComponent<SoundsManager>().Attack();
		_animationManager.anim.SetTrigger("attack");

		StartCoroutine(AttackCooldown());
	}
	void Attack_BRAIN () {
		_canAttack = false;

		GetComponent<SoundsManager>().Attack();
		_animationManager.anim.SetTrigger("attack");

		StartCoroutine(AttackCooldown());
	}
	void Attack_PRIEST () {
		_canAttack = false;

		GetComponent<SoundsManager>().Attack();
		_animationManager.anim.SetTrigger("attack");

		StartCoroutine(AttackCooldown());
	}
	void Attack_HATCHER () {
		_canAttack = false;

		GetComponent<SoundsManager>().Attack();
		_animationManager.anim.SetTrigger("attack");

		StartCoroutine(AttackCooldown());
	}

	public void Attack_StartCheck () {
		_canCheckHit = true;
	}
	public void Attack_EndCheck () {
		_canCheckHit = false;
	}

	IEnumerator AttackCooldown () {
		yield return new WaitForSeconds(attackCooldown);
		_canAttack = true;
		_canCheckHit = false;
	}

	IEnumerator GameStart () {
		yield return new WaitForSeconds(0.25f);
		_canAttack = true;
	}

	public void StartAttack () {
		_animationManager.anim.SetBool("attacking", true);
	}
	public void EndAttack () {
		_animationManager.anim.SetBool("attacking", false);
	}
}
