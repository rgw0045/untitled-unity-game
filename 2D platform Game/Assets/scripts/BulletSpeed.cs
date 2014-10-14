using UnityEngine;
using System.Collections;

public class BulletSpeed : MonoBehaviour {
	public float speed;
	float mouseY = Input.mousePosition.y;
	float mouseX = Input.mousePosition.x;
	
	// Use this for initialization
	void Start () {
		  rigidbody2D.AddForce(new Vector2(mouseX, mouseY));
	}

}
