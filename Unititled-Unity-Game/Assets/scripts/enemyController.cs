using UnityEngine;
using System.Collections;

public class enemyController : MonoBehaviour {
	//variables for moving
	public float maxSpeed = 10f;
	bool facingRight = true;
	public float maxHealth = 100;
	float curHealth;

	public GameObject arm;
	float playerX;
	float playerY;
	float playerZ;
	Vector3 Player;

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

	private int scoreValue = 50;

	bool doubleJump = false;

	void Start() {
		//gets the animator
		anim = GetComponent <Animator> ();
		anim.SetBool ("FacingRight", facingRight);
		curHealth = maxHealth;
	}

	void FixedUpdate() {
		//check to see if i am on the ground
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool ("Ground", grounded);

		if (grounded)
			doubleJump = false;

		//jumping animation
		anim.SetFloat ("vSpeed", rigidbody2D.velocity.y);

		//gets input to move the character
		float move = 0;

		//gets the speed for the animator
		anim.SetFloat ("speed", move);

		//moves charactor
		rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);

		playerX = GameObject.Find("Player").transform.position.x - transform.position.x;

		//if moving left and not facing right, flip
		if (playerX > 0 && !facingRight) {
			Flip ();
		}
		//if moving left and not facing left, flip
		else if (playerX < 0 && facingRight) {
			Flip ();
		}
	}

	void Update() {
		if (curHealth <= 0) {
			Destroy (this.gameObject);
			ScoreKeeper.Addscore(scoreValue);
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
	public void AdjustcurHealth(int adj) {
				curHealth += adj;
		}
}
