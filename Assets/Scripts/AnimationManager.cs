using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour {
	private ControllerPlayerID _id;
	public Animator anim;

	void Start () {
		_id = GetComponent<ControllerPlayerID>();
		StartCoroutine(WaitForAnimator());
	}
	IEnumerator WaitForAnimator () {
		yield return null;
		yield return null;
		anim = _id.skinTransform.GetComponent<MonsterAnimatorLink>().anim;
		anim.Play(0,-1, Random.value);
	}
}
