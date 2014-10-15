using UnityEngine;
using System.Collections;

public class BulletSpeed : MonoBehaviour {
	public float speed;
	Vector3 Mouse;
	public GameObject player;

	float mouseY = Input.mousePosition.y;
	float mouseX = Input.mousePosition.x;
	float mouseZ = Input.mousePosition.z;
	
	// Use this for initialization
	void Start () {

		Mouse = new Vector3 (mouseX, mouseY, mouseZ);

		Vector3 difference = Camera.main.ScreenToWorldPoint (Mouse) - transform.position;

		rigidbody2D.AddForce(new Vector2(difference.x * speed, difference.y * speed));
	}

}
