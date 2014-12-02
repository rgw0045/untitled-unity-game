using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour {

	Animator animator;
	LayerMask whatIsGround;
	Object BossBullet;
	Transform boss;
	Transform player;
	Transform shotSpawn;
	Transform groundCheck;
	Transform forwardGroundCheck;
	Transform forwardWallCheck;
	Vector2 playerRelPos;

	
	float attackRange = 15.0f;
	float fireRate = 0.1f;
	float nextFire = 0.0f;
	float groundRadius = 0.2f;
	float maxSpeed = 1.0f;

	//to look for the player.
	public 

	// Use this for initialization
	void Start () {
		animator = GetComponent <Animator> ();
		player = GameObject.Find("Player").transform;
		boss = transform;
		whatIsGround = LayerMask.GetMask("Walls") + 1;
		groundCheck = boss.Find("GroundCheck");
		shotSpawn = boss.Find("ShotSpawn");
		forwardGroundCheck = boss.Find("ForwardGroundCheck");
		forwardWallCheck = boss.Find("ForwardWallCheck");
		BossBullet = Resources.Load("BossCar");
	}

	void FixedUpdate() {
		// get the player's position relative to this enemy's position
		playerRelPos = Vector2.Scale(player.position - boss.position, boss.localScale);
		
		// check if veiw of the player is blocked
		bool viewBlocked = Physics2D.Linecast(boss.position, player.position, LayerMask.GetMask("Walls") + 1).transform;
		
		// if the player is in front and is in range attack the player
		if (playerRelPos.x > 0.0f && playerRelPos.magnitude < attackRange && !viewBlocked) attack(playerRelPos);
		else patrol();

		// set animation states
		animator.SetFloat ("speed", rigidbody2D.velocity.x * boss.localScale.x);


		}
	//attacks the player
	void attack(Vector2 playerRelPos) {
		// stop moving
		rigidbody2D.velocity = new Vector2 (0.0f, rigidbody2D.velocity.y);
		
		// get the relative and absolute angle of the player
		float playerRelAng = 90.0f - Vector2.Angle(Vector2.up, playerRelPos);
		
		// shoot if enough time has passed
		if (Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Quaternion shotRot;
			if (boss.localScale.x > 0.0f) shotRot = Quaternion.Euler (0.0f, 0.0f, playerRelAng);
			else shotRot = Quaternion.Euler (0.0f, 0.0f, 180.0f - playerRelAng);
			Instantiate(BossBullet, shotSpawn.position, shotRot);
		}
	}

	void patrol() {
		
		// flip if about to walk off platform or against a wall
		bool grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		bool forwardGrounded = Physics2D.OverlapCircle (forwardGroundCheck.position, groundRadius, whatIsGround);
		bool forwardWalled =  Physics2D.OverlapCircle (forwardWallCheck.position, groundRadius, whatIsGround);
		if (grounded && (!forwardGrounded || forwardWalled)) boss.localScale = new Vector2(boss.localScale.x * -1, boss.localScale.y);

		//for the boss to randomly teleport
		if(Random.Range(0, 100)  == 5) {
		  Vector3 playerPosRandomized = player.transform.position;
		  playerPosRandomized.x = playerPosRandomized.x + Random.Range (-10.0f, 10.0f);
		  playerPosRandomized.y = playerPosRandomized.y + Random.Range (1.0f, 10.0f);
		  boss.transform.position = playerPosRandomized;
		}
		// walk forward
		//rigidbody2D.velocity = new Vector2 (maxSpeed * boss.localScale.x, rigidbody2D.velocity.y);
	}


	float curHealth = 250.0f;
	public void AdjustcurHealth(int adj) {
		curHealth += adj;
		if (curHealth <= 0) Destroy (this.gameObject);
	}
}
