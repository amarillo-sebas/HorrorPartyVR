using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEffects : MonoBehaviour {
	[Space(5f)]
	[Header("Dependencies")]
	public ParticleSystem ps;
	public PriestAttack priestAttack;
	public HatcherAttack hatcherAttack;

	[Space(5f)]
	[Header("Variables")]
	public MonsterType type;

	public void Attack () {
		switch (type) {
			case MonsterType.Drone:
				
			break;
			case MonsterType.Brain:
				
			break;
			case MonsterType.Priest:
				priestAttack.Attack();
			break;
			case MonsterType.Hatcher:
				hatcherAttack.Attack();
			break;
		}
	}
}
