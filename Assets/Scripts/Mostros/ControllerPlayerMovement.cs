﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ControllerPlayerID))]
public class ControllerPlayerMovement : MonoBehaviour {
	private ControllerPlayerID _id;
	private CharacterController _controller;
	private AnimationManager _animationManager;

	public float moveSpeed;
	public float rotationSpeed;
	//private float _gravity = 5f;
	public float deadZone = 0.3f;

	public bool canMove = true;
	
	public ControllerPlayerHP hp;

	void Start () {
		_id = GetComponent<ControllerPlayerID>();
		_controller = GetComponent<CharacterController>();
		_animationManager = GetComponent<AnimationManager>();
	}
	
	void Update () {
		if (hp.isAlive) if (canMove) {
			float xMovement = Input.GetAxis(_id.playerNumber + "_horizontal");
			if (Mathf.Abs(xMovement) < deadZone) xMovement = 0f;
			float yMovement = Input.GetAxis(_id.playerNumber + "_vertical");
			if (Mathf.Abs(yMovement) < deadZone) yMovement = 0f;

			Vector3 moveDirection = new Vector3(xMovement, 0, yMovement);
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= moveSpeed;
			moveDirection.y += Physics.gravity.y / 2f;
			moveDirection.z = -moveDirection.z;
			
			_controller.Move(moveDirection * Time.deltaTime);

			moveDirection.y = 0f;
			if (_animationManager.anim) _animationManager.anim.SetFloat("speed", moveDirection.magnitude);

			if (moveDirection.magnitude > 0) {
				Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
				_id.skinTransform.rotation = Quaternion.Slerp(_id.skinTransform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
			}
		}	
	}
}
