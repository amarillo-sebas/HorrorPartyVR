﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour {
	public Animator anim;

	void Start () {
		anim.Play(0,-1, Random.value);
	}
}
