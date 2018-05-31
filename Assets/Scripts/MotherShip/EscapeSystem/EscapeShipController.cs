using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeShipController : MonoBehaviour {
	public Animator myAnimator;
	public GameObject particles;

	private Transform player;

	public void BlastOff () {
		player = GameObject.FindGameObjectWithTag("Player").transform;
		player.parent = transform;
		myAnimator.SetTrigger("BlastOff");
		particles.SetActive(true);
	}
}
