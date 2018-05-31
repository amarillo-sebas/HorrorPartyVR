using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingRoomController : MonoBehaviour {
	public Animator myAnimator;
	public StartingRoomAudio audio;

	void Start () {
		Light l = GetComponentInChildren<Light>();
		GameObject mc = GameObject.FindWithTag("MonsterCamera");
		mc.GetComponent<HideLightsFromCamera>().Lights.Add(l);
	}

	public void OpenDoor () {
		myAnimator.SetTrigger("Open");
		audio.Door();
	}
	
	public void CloseDoor () {
		myAnimator.SetTrigger("Close");
		audio.Door();
	}
}
