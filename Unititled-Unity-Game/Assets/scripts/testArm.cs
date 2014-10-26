using UnityEngine;
using System.Collections;

public class testArm : MonoBehaviour {
	Vector3 worldPos;
	float mouseX;
	float mouseY;
	float cameraDif;

	public GameObject gun;

	// Use this for initialization
	void Start () {
		cameraDif = gun.transform.position.y - camera.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		mouseX = Input.mousePosition.x;
		mouseY = Input.mousePosition.y;

		worldPos = camera.ScreenToWorldPoint(new Vector3(mouseX, mouseY, cameraDif));

		gun.transform.LookAt(worldPos);
	}
}
