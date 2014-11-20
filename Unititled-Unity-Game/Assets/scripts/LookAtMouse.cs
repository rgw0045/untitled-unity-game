using UnityEngine;
using System.Collections;

public class LookAtMouse : MonoBehaviour {

	public float rotationOffset;
	float mouseX;
	float mouseY;
	Vector2 Mouse;

	// Update is called once per frame
	void Update () {
		mouseX = Input.mousePosition.x;
		mouseY = Input.mousePosition.y;

		Mouse = new Vector2 (mouseX, mouseY);
		//gets the distance beteween the mouse position and the player then normalized the vectot
		Vector2 difference = Camera.main.ScreenToWorldPoint (Mouse) - transform.position;
		difference.Normalize ();
		//rotates the arm so it points at the player.
		float rotateZ = Mathf.Atan2 (difference.y, difference.x) * Mathf.Rad2Deg;
	    transform.rotation = Quaternion.Euler (0f, 0f, rotateZ * rotationOffset);
	}
}
