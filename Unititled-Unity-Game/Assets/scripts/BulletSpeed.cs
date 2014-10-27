using UnityEngine;
using System.Collections;

public class BulletSpeed : MonoBehaviour {
	public float speed;
	public float range;
	float distance;
	Vector3 Mouse;

	float mouseY = Input.mousePosition.y;
	float mouseX = Input.mousePosition.x;
	
	// Use this for initialization
	void Start () {
		distance = 0.0f;
		
		Mouse = new Vector2 (mouseX, mouseY);

		Vector2 difference = Camera.main.ScreenToWorldPoint (Mouse) - transform.position;
		difference.Normalize();

		rigidbody2D.velocity = difference * speed;

	}

	void FixedUpdate() {
		distance += speed;
		if (distance >= range) Destroy(this.gameObject);
	}
}