using UnityEngine;
using System.Collections;

public class BulletSpeed : MonoBehaviour {
	public float speed;

	// Use this for initialization
	void Start () {
		rigidbody2D.velocity = transform.forward * speed;
	}

}
