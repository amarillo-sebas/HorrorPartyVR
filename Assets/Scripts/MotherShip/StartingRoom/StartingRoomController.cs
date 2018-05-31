using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingRoomController : MonoBehaviour {
	public Animator myAnimator;
	public StartingRoomAudio audio;

	public void OpenDoor () {
		myAnimator.SetTrigger("Open");
		audio.Door();
	}
	
	public void CloseDoor () {
		myAnimator.SetTrigger("Close");
		audio.Door();
	}
}
