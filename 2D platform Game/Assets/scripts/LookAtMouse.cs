using UnityEngine;
using System.Collections;

public class LookAtMouse : MonoBehaviour {

	public float rotationOffset;
	public GameObject player;
	float mouseX;
	float mouseY;
	float mouseZ;
	Vector3 Mouse;

	// Update is called once per frame
	void Update () {
		mouseX = Input.mousePosition.x;
		mouseY = Input.mousePosition.y;
		mouseZ = Input.mousePosition.z;
		 
		Mouse = new Vector3 (mouseX, mouseY, mouseZ);

		Vector3 difference = Camera.main.ScreenToWorldPoint (Mouse) - transform.position;
		difference.Normalize ();

		float rotateZ = Mathf.Atan2 (difference.y, difference.x) * Mathf.Rad2Deg;

		if ((rotateZ * rotationOffset) > 60 && (rotateZ * rotationOffset) < 90)
			transform.rotation = Quaternion.Euler (0f, 0f, 60f);
		else if ((rotateZ * rotationOffset) > -90 && (rotateZ * rotationOffset) < -40)
			transform.rotation = Quaternion.Euler (0f, 0f, -40f);
		else
		     transform.rotation = Quaternion.Euler (0f, 0f, rotateZ * rotationOffset);

	}
}
