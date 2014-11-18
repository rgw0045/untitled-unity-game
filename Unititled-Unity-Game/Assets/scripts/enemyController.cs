using UnityEngine;
using System.Collections;

public class enemyController : MonoBehaviour {
	// public variables
	public float maxSpeed = 1.0f;
	public float fireRate = 0.1f;
	public float groundRadius = 0.2f;
	public float maxHealth = 100;
	public GameObject arm;
	public GameObject shot;
	public Transform shotSpawn;
	public Transform groundCheck;
	public Transform forwardGroundCheck;
	public Transform forwardWallCheck;
	public LayerMask whatIsGround;

	// global variables
	bool facingRight = true;
	bool movingRight = true;
	public bool grounded = false;
	public bool forwardGrounded = false;
	public bool forwardWalled = false;
	float curHealth;
	Vector3 playerPos;
	Animator anim;

	void Start() {
		// gets this object's animator
		anim = GetComponent <Animator> ();
		anim.SetBool ("FacingRight", facingRight);
		curHealth = maxHealth;

	}

	void FixedUpdate() {
		// check to see if i am on the ground
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool ("Ground", grounded);

		// check to see if my forward ground check is on the ground
		forwardGrounded = Physics2D.OverlapCircle (forwardGroundCheck.position, groundRadius, whatIsGround);

		// check to see if my forward wall check is against a wall
		forwardWalled =  Physics2D.OverlapCircle (forwardWallCheck.position, groundRadius, whatIsGround);
		
		// decide which direction to move
		if (grounded && (!forwardGrounded || forwardWalled)) movingRight = !movingRight;

		// move the character
		float xVelocity;
		if (grounded) {
			if (movingRight) xVelocity = maxSpeed;
			else xVelocity = -maxSpeed;
		}
		else xVelocity = 0.0f;
		rigidbody2D.velocity = new Vector2 (xVelocity, rigidbody2D.velocity.y);
		anim.SetFloat ("speed", xVelocity);
		
		//if moving left and not facing right, flip
		if ((rigidbody2D.velocity.x > 0 && !facingRight) || (rigidbody2D.velocity.x < 0 && facingRight)) Flip();
	}

	void Update() {
		if (curHealth <= 0) Destroy (this.gameObject);
	}
	
	//function to flip the walking animation
	void Flip() {
		facingRight = !facingRight;
		anim.SetBool ("FacingRight", facingRight);
		transform.localScale = new Vector2 (-transform.localScale.x, transform.localScale.y);
	}
	
	public void AdjustcurHealth(int adj) {
		curHealth += adj;
	}
}
