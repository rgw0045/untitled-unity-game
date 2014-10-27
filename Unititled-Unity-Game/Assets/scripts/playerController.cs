using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {
	//variables for moving
	public float maxSpeed = 10f;
	bool facingRight = true;

	public GameObject arm;
	float mouseX;
	float mouseY;
	float mouseZ;
	Vector3 Mouse;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	private float nextFire;

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
		anim.SetBool ("FacingRight", facingRight);

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
		//if (!grounded)
		//	return;

		//gets input to move the character
		float move = Input.GetAxis ("Horizontal");

		//gets the speed for the animator
		anim.SetFloat ("speed", move);

		//moves charactor
		rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);

		mouseX = Camera.main.ScreenToWorldPoint (Input.mousePosition).x - transform.position.x;

		//if moving left and not facing right, flip
		if (mouseX > 0 && !facingRight) {
			Flip ();
		}
		//if moving left and not facing left, flip
		else if (mouseX < 0 && facingRight) {
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
		//to fire gun after the mouse is clicked.
		if (Input.GetButton("Fire1") && Time.time > nextFire) {
			
			Vector3 difference = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position;
			difference.Normalize ();
			
			float angle = Mathf.Atan2 (difference.y, difference.x) * Mathf.Rad2Deg;

			if ((angle > -40 && angle < 60) || (angle > 120 || angle < -140)) {
			  nextFire = Time.time + fireRate;
			  Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			}
	    }
	}
	//function to flip the walking animation
	void Flip() {
		facingRight = !facingRight;
		anim.SetBool ("FacingRight", facingRight);
		if (!facingRight) {
			Quaternion theScale = transform.localRotation;
			theScale.y = 180;
			transform.localRotation = theScale;
		}
		else {
			Quaternion theScale = transform.localRotation;
			theScale.y = 0;
			transform.localRotation = theScale;
		}
		Vector3 theArmScale = arm.transform.localScale;
		//theScale.x *= -1;
		theArmScale.y *= -1;
		arm.transform.localScale = theArmScale;
	}
}
