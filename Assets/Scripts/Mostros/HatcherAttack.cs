using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatcherAttack : MonoBehaviour {
	[Space(5f)]
	[Header("Dependencies")]
	public GameObject hatcherEgg;

	[Space(5f)]
	[Header("Variables")]
	public int maxEggs;
	public List<HatcherEgg> eggs = new List<HatcherEgg>();
	private int _eggsNumber = 0;

	void Start () {

	}

	public void Attack () {
		if (_eggsNumber < maxEggs) {
			GameObject e = Instantiate(hatcherEgg, transform.position, transform.rotation);
			eggs.Add(e.GetComponent<HatcherEgg>());
			e.GetComponent<HatcherEgg>().hatcher = this;
			_eggsNumber++;
		} else {
			eggs[0].Abort();
			eggs.RemoveAt(0);
			_eggsNumber--;
			GameObject e = Instantiate(hatcherEgg, transform.position, transform.rotation);
			eggs.Add(e.GetComponent<HatcherEgg>());
			e.GetComponent<HatcherEgg>().hatcher = this;
			_eggsNumber++;
		}
	}

	public void RemoveEgg (HatcherEgg e) {
		eggs.Remove(e);
		_eggsNumber--;
	}
}
