using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player;
	private Vector3 offset;
	private Vector3 jumping;
	
	
	// Use this for initialization
	void Start () {
		offset = new Vector3 (0, transform.position.y, transform.position.z);
	}
	
	// Update is called once per frame
	void LateUpdate () {
			transform.position = player.transform.position + offset;
	}
}
