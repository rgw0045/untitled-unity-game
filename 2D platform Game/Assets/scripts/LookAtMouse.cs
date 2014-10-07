using UnityEngine;
using System.Collections;

public class LookAtMouse : MonoBehaviour {

	public float cameraDif = 10.0f;
	//Vector3 pos;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = Vector3(Input.mousePosition.x, Input.mousePosition.y, cameraDif);
		pos = Camera.main.ScreenToWorldPoint(pos);
		transform.position = pos;
	}
}
