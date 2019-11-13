using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using UnityEngine.UI;

public class InteractableLightBaton : VRTK_InteractableObject {
	[Space(5f)]
	[Header("Dependencies")]
	public Animator anim;
	public Slider slider;
	public BatonAudio batonAudio;
	public Light light;
	private HideLightsFromCamera _hlfc;

	[Space(5f)]
	[Header("Variables")]
	public float charge = 1f;
	public float dischargeRate;
	public float chargeRate;
	private bool _using = false;
	public int damage;
	public float pushForce;
	public float chargeLostOnHit;
	private float _hitInterval = 0.25f;
	private bool _hitCooldown = false;

	IEnumerator Start () {
		_hlfc = FindObjectOfType(typeof(HideLightsFromCamera)) as HideLightsFromCamera;
		if (_hlfc) _hlfc.Lights.Add(light);
		yield return null;
		//light.enabled = false;
	}

	public override void StartUsing(VRTK_InteractUse usingObject) {
		base.StartUsing(usingObject);
		anim.SetBool("Active", true);
		_using = true;
		batonAudio.PlayOpen();
	}

	public override void StopUsing(VRTK_InteractUse usingObject) {
		base.StopUsing(usingObject);
		anim.SetBool("Active", false);
		_using = false;
		batonAudio.PlayClose();
	}

	public override void Grabbed(VRTK_InteractGrab currentGrabbingObject = null) {
		base.Grabbed(currentGrabbingObject);
		anim.SetBool("Active", false);
		light.gameObject.SetActive(true);
	}

	public virtual void Ungrabbed(GameObject previousGrabbingObject) {
		base.Grabbed(previousGrabbingObject);
	}
	
	void Update () {
		base.Update();
		if (_using) {
			charge -= dischargeRate * Time.deltaTime;
			if (charge <= 0f) {
				charge = 0f;
				_using = false;
				anim.SetBool("Active", false);
				batonAudio.PlayClose();
			}
		} else {
			charge += chargeRate * Time.deltaTime;
			if (charge >= 1f) charge = 1f;
		}

		slider.value = charge;
	}

	void OnTriggerEnter (Collider c) {
		if (_using && !_hitCooldown) if (c.tag == "Mostro") {
			CharacterControllerImpactEnforcer ccie = c.GetComponent<CharacterControllerImpactEnforcer>();
			if (ccie) {
				Vector3 dir = c.transform.position - transform.position;
				dir.y = 0f;
				ccie.AddImpact(dir, pushForce);
			}

			ControllerPlayerHP cphp = c.GetComponent<ControllerPlayerHP>();
			if (cphp) {
				cphp.TakeDamage(damage);
				charge -= chargeLostOnHit;
				if (charge < 0f) charge = 0f;
				_hitCooldown = true;
				batonAudio.PlayHit();
				StartCoroutine(HitCooldown());
			}
		}
	}

	IEnumerator HitCooldown () {
		yield return new WaitForSeconds(_hitInterval);
		_hitCooldown = false;
	}
}
