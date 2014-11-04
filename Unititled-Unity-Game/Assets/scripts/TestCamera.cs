using UnityEngine;
using System.Collections;

public class TestCamera : MonoBehaviour {

	public float dragSpeed = 2.0f;
	private Vector3 dragOrigin;
	private bool isPanning;
	
	
	// Use this for initialization
	void Start () 
	{
		
	}
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButtonDown(0)) 
		{
			dragOrigin = Input.mousePosition;
			isPanning = true;
		}
		
		if (!Input.GetMouseButton(0)) 
		{
			isPanning = false;
		}
		
		if (isPanning) 
		{
			Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
			
			Vector3 move = new Vector3(pos.x * dragSpeed, pos.y * dragSpeed, 0);
			transform.Translate(move, Space.Self);
			
			transform.position = new Vector3(Mathf.Clamp(transform.position.x, -10,10),Mathf.Clamp(transform.position.y, -10,10),0);
		}
	}


}
