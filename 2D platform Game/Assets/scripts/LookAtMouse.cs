using UnityEngine;
using System.Collections;

public class LookAtMouse : MonoBehaviour {

	public float rotationOffset = 10.0f;

	// Update is called once per frame
	void Update () {
		Vector3 difference = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position;
		difference.Normalize ();

		float rotateZ = Mathf.Atan2 (difference.y, difference.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler (0f, 0f, rotateZ * rotationOffset);
	}
}
