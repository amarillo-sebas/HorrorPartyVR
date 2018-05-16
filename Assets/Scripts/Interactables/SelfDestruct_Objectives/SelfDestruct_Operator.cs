using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct_Operator : MonoBehaviour {
	public bool[] objectivesActive;
	private bool _readyToBlow;
	private MotherShipMissionManager _msmm;

	void Start () {
		_msmm = FindObjectOfType<MotherShipMissionManager>();
	}
	
	void Update () {
		
	}

	public void StartMission () {
		_msmm.StartMission();
	}

	public void ObjectiveState (bool b, int i) {
		objectivesActive[i] = b;
		_readyToBlow = true;
		foreach (bool r in objectivesActive) {
			if (!r) {
				_readyToBlow = false;
			}
		}
		if (_readyToBlow) {
			SelfDestruct();
		}
	}

	public void SelfDestruct () {
		_msmm.StartSelfDestructCountdown();
	}
}
