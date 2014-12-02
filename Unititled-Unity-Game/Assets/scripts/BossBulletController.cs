using UnityEngine;
using System.Collections;

public class BossBulletController : MonoBehaviour {
	public float speed;
	public float range;
	HealthBar health;
	
	Vector3 startPosition;
	Vector2 vector;
	float distance;
	
	Vector2 target;
	
	// Use this for initialization
	void Start () {
		startPosition = transform.position;
		
		target = GameObject.Find("Player").transform.position;
		
		Vector2 difference = target - (Vector2)transform.position;
		
		rigidbody2D.velocity = difference.normalized * speed;
		
	}
	
	void Update() {
		vector = transform.position - startPosition;
		distance = vector.magnitude;
		if (distance >= range) Destroy(this.gameObject);
	}
	
	void OnTriggerEnter2D(Collider2D coll) {
		
		if(coll.gameObject.tag == "Player") {
			Destroy(this.gameObject);
			
			coll.gameObject.SendMessage("AdjustcurHealth", -25);
		}
		
	}
}
