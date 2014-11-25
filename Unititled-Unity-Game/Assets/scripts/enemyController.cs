using UnityEngine;
using System.Collections;

public class enemyController : MonoBehaviour {
	Animator animator;
	LayerMask whatIsGround;
	Object enemyBullet;
	Transform enemy;
    Transform player;
	Transform weaponArm;
	Transform shotSpawn;
	Transform groundCheck;
	Transform forwardGroundCheck;
	Transform forwardWallCheck;

	float attackRange = 8.0f;
	float fireRate = 0.1f;
	float nextFire = 0.0f;
	float groundRadius = 0.2f;
	float maxSpeed = 1.0f;
	
	void Start () {
		animator = GetComponent <Animator> ();
		player = GameObject.Find("Player").transform;
		enemy = transform;
		weaponArm = enemy.Find("WeaponArm");
		shotSpawn = weaponArm.Find("ShotSpawn");
		whatIsGround = LayerMask.GetMask("Walls") + 1;
		groundCheck = enemy.Find("GroundCheck");
		forwardGroundCheck = enemy.Find("ForwardGroundCheck");
		forwardWallCheck = enemy.Find("ForwardWallCheck");
		enemyBullet = Resources.Load("EnemyBullet");
	}
	
	void FixedUpdate () {
		// get the player's position relative to this enemy's position
		Vector2 playerRelPos = Vector2.Scale(player.position - enemy.position, enemy.localScale);
		
		// check if veiw of the player is blocked
		bool viewBlocked = Physics2D.Linecast(enemy.position, player.position, LayerMask.GetMask("Walls") + 1).transform;
		
		// if the player is in front and is in range attack the player
		if (playerRelPos.x > 0.0f && playerRelPos.magnitude < attackRange && !viewBlocked) attack(playerRelPos);
		else patrol();
		
		// set animation states
		animator.SetFloat ("speed", rigidbody2D.velocity.x * enemy.localScale.x);
	}
	
	void attack(Vector2 playerRelPos) {
		// stop moving
		rigidbody2D.velocity = new Vector2 (0.0f, rigidbody2D.velocity.y);
		
		// get the relative and absolute angle of the player
		float playerRelAng = 90.0f - Vector2.Angle(Vector2.up, playerRelPos);
		
		// point gun at player
		weaponArm.rotation = Quaternion.Euler (0.0f, 0.0f, playerRelAng);
		
		// shoot if enough time has passed
		if (Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Quaternion shotRot;
			if (enemy.localScale.x > 0.0f) shotRot = Quaternion.Euler (0.0f, 0.0f, playerRelAng);
			else shotRot = Quaternion.Euler (0.0f, 0.0f, 180.0f - playerRelAng);
			Instantiate(enemyBullet, shotSpawn.position, shotRot);
	    }
	}
	
	void patrol() {
		// point gun forward
		weaponArm.rotation = Quaternion.Euler (0.0f, 0.0f, 0.0f);
		
		// flip if about to walk off platform or against a wall
		bool grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		bool forwardGrounded = Physics2D.OverlapCircle (forwardGroundCheck.position, groundRadius, whatIsGround);
		bool forwardWalled =  Physics2D.OverlapCircle (forwardWallCheck.position, groundRadius, whatIsGround);
		if (grounded && (!forwardGrounded || forwardWalled)) enemy.localScale = new Vector2(enemy.localScale.x * -1, enemy.localScale.y);
		
		// walk forward
		rigidbody2D.velocity = new Vector2 (maxSpeed * enemy.localScale.x, rigidbody2D.velocity.y);
	}

	float curHealth = 100.0f;
	public void AdjustcurHealth(int adj) {
		curHealth += adj;
		if (curHealth <= 0) Destroy (this.gameObject);
	}
}
