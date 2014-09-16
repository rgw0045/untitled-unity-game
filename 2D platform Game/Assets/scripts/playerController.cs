﻿using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {
	//variables for moving
	public float maxSpeed = 10f;
	bool facingRight = true;

	Animator anim;

	//variables to fall
	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public float jumpForce = 700f;

	bool doubleJump = false;

	void Start() {
		//gets the animator
		anim = GetComponent <Animator> ();
	}

	void FixedUpdate() {
		//check to see if i am on the ground
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool ("Ground", grounded);

		if (grounded)
			doubleJump = false;

		//jumping animation
		anim.SetFloat ("vSpeed", rigidbody2D.velocity.y);

		//cant move while jumping
		if (!grounded)
			return;

		//gets input to move the character
		float move = Input.GetAxis ("Horizontal");

		//gets the speed for the animator
		anim.SetFloat ("speed", Mathf.Abs (move));

		//moves charactor
		rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);
		//if moving left and not facing right, flip
		if (move > 0 && !facingRight) {
			Flip ();
		}
		//if moving left and not facing left, flip
		else if (move < 0 && facingRight) {
			Flip ();
		}
	}

	void Update() {
		//to jump and after pressing the spacebar
		if ((grounded || !doubleJump) && Input.GetKeyDown (KeyCode.Space)) {
			anim.SetBool("Ground", false);
			rigidbody2D.AddForce(new Vector2(0, jumpForce));

			if(!doubleJump && !grounded)
				doubleJump = true;
		}

	}
	//function to flip the walking animation
	void Flip() {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

}
