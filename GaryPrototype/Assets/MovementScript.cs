using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour {
	const float moveForce = 40f;	// Amount of force added to move the player left and right.
	const float maxSpeed = 5f;		// The fastest the player can travel in the x axis.
	const float jumpForce = 1000f;	// Amount of force added when the player jumps.
	
	Transform groundCheck;			// A position marking where to check if the player is grounded.
	float moveInput;				// Condition for whether the player should move.
	bool jumpInput;					// Condition for whether the player should jump.
	
	// Awake is called when the script instance is being loaded.
	void Awake() {
		groundCheck = transform.Find("groundCheck");
	}

	// Update is called every frame.
	void Update() {
		moveInput = Input.GetAxis("Horizontal");
		jumpInput = Input.GetButtonDown("Jump") || Input.GetAxis("Vertical") > 0;
	}

	// FixedUpdate is called every fixed framerate frame.
	void FixedUpdate() {
		float velocity = rigidbody2D.velocity.x;
		bool grounded = Physics2D.Linecast(transform.position, groundCheck.position);
	
		if (moveInput * velocity < maxSpeed) rigidbody2D.AddForce(Vector2.right * moveInput * moveForce);
		
		if (jumpInput && grounded) rigidbody2D.AddForce(Vector2.up * jumpForce);
	}
}