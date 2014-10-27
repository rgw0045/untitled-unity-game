using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {

	public Transform Destination;
	public Transform Origin;
	public float speed;
	public bool Switch = false;

	void FixedUpdate()
	{
		if (transform.position == Destination.position) 
		{
			Switch = true;
		}

		if (transform.position == Origin.position) 
		{
			Switch = false;
		}

		if (Switch) 
		{
			transform.position = Vector2.MoveTowards (transform.position, Origin.position, speed);
		} 
		else 
		{
			transform.position = Vector2.MoveTowards(transform.position, Destination.position, speed);
		}


	}
	void OnCollisionEnter2D(Collision2D coll) {

		if(coll.gameObject.tag == "Player") {
			coll.gameObject.transform.parent = transform;
		}

	}
	void OnCollisionExit2D(Collision2D coll) {
		  if (coll.gameObject.tag == "Player") {
			coll.gameObject.transform.parent = null;
		  }
		}

}
