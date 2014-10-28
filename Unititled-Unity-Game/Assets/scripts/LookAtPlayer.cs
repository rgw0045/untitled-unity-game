using UnityEngine;
using System.Collections;

public class LookAtPlayer : MonoBehaviour {
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	public float attackRange;
	
	Vector2 playerVector;
	float playerAngle;
	float playerDistance;

	float nextFire;

	// Update is called once per frame
	void Update () {
		playerVector = (GameObject.Find("Player")).transform.position - transform.position;
		playerAngle = Mathf.Atan2 (playerVector.normalized.y, playerVector.normalized.x) * Mathf.Rad2Deg;
		playerDistance = playerVector.magnitude;
		
		if ((playerAngle) > 60 && (playerAngle) < 90)
			transform.rotation = Quaternion.Euler (0f, 0f, 60f);
		else if ((playerAngle) > -90 && (playerAngle) < -40)
			transform.rotation = Quaternion.Euler (0f, 0f, -40f);
		else if ((playerAngle) < 120 && (playerAngle) > 90)
			transform.rotation = Quaternion.Euler (0f, 0f, 120f);
		else if ((playerAngle) < -90 && (playerAngle) > -140)
			transform.rotation = Quaternion.Euler (0f, 0f, -140f);
		else
			transform.rotation = Quaternion.Euler (0f, 0f, playerAngle);
			
			
		if (playerDistance <= attackRange && Time.time > nextFire) {
			if ((playerAngle > -40 && playerAngle < 60) || (playerAngle > 120 || playerAngle < -140)) {
			  nextFire = Time.time + fireRate;
			  Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			}
	    }
	}
}
