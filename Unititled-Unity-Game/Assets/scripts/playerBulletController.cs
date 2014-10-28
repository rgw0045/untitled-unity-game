using UnityEngine;
using System.Collections;

public class playerBulletController : MonoBehaviour {
	public float speed;
	public float range;

	Vector3 startPosition;
	Vector2 vector;
	float distance;

	Vector2 target;
	
	// Use this for initialization
	void Start () {
		startPosition = transform.position;
		
		target = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		Vector2 difference = target - (Vector2)transform.position;

		rigidbody2D.velocity = difference.normalized * speed;

	}
	
	void Update() {
		vector = transform.position - startPosition;
		distance = vector.magnitude;
		if (distance >= range) Destroy(this.gameObject);
	}
}