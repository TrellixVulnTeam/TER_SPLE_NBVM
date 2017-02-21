﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Controller2D))]

public class Player : MonoBehaviour {

	public float jumpHeight = 1.5f;
	public float timeToJumpApex = 0.35f;
	float gravity;
	float accelerationTimeAirborne = 0.2f;
	float accelerationTimeGrounded = 0.1f;
	float moveSpeed = 6;
	float velocityXSmoothing;

	Vector3 velocity;
	float jumpVelocity;
	Controller2D controller;

	void Start () {
		controller = GetComponent<Controller2D>();
		gravity = -(2 * jumpHeight) / Mathf.Pow (timeToJumpApex, 2);
		jumpVelocity = Mathf.Abs (gravity) * timeToJumpApex;
		//print("Gravity :"+ gravity + " jump velocity : "+jumpVelocity);
	}
	
	// Update is called once per frame
	void Update () {
		if (controller.collisions.above || controller.collisions.below) {
			velocity.y = 0;
		}

		Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		if (Input.GetKeyDown (KeyCode.UpArrow) && controller.collisions.below) {
			velocity.y = jumpVelocity;
		}
		float targetVelocityX = input.x * moveSpeed; 
		velocity.x = Mathf.SmoothDamp (velocity.x, targetVelocityX, ref velocityXSmoothing, controller.collisions.below?accelerationTimeGrounded:accelerationTimeAirborne);
		velocity.y += gravity * Time.deltaTime;
		controller.Move (velocity * Time.deltaTime);
	}
}
