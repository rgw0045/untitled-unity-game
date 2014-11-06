using UnityEngine;
using System.Collections;

public class NewCameraController : MonoBehaviour {

	public Transform player;

	public Vector2 Margin;
	public Vector2 smoothing;

	public BoxCollider2D Bounds;

	public bool isFollowing { get; set;}

	private Vector3 _min, _max;

	public void Start(){

		_min = Bounds.bounds.min;
		_max = Bounds.bounds.max;
		isFollowing = true;
	}

	public void Update(){

		var x = transform.position.x;
		var y = transform.position.y;

		if (isFollowing) {
			if(Mathf.Abs(x - player.position.x) > Margin.x)	
				x = Mathf.Lerp(x, player.position.x, smoothing.x * Time.deltaTime);
		
			if(Mathf.Abs(y - player.position.y) > Margin.y)
				y = Mathf.Lerp(y, player.position.y, smoothing.x * Time.deltaTime);
								
		}

		var cameraHalfWidth = camera.orthographicSize * ((float)Screen.width / Screen.height);
		x = Mathf.Clamp (x, _min.x + cameraHalfWidth, _max.x - cameraHalfWidth);
		y = Mathf.Clamp (y, _min.y + camera.orthographicSize, _max.y - camera.orthographicSize);

		transform.position = new Vector3 (x, y, transform.position.z);
	}

}
