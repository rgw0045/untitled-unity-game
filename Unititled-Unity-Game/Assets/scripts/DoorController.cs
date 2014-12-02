using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {
	Animator animator;
	Transform door;
	Transform player;

	public float playerRange;
	
	float openRange = 10.0f;

	// Use this for initialization
	void Start () {
		animator = GetComponent <Animator> ();
		door = transform;
		player = GameObject.Find("Player").transform;
	}
	
	void FixedUpdate () {
		playerRange = Vector2.Scale(player.position - door.position, door.localScale).magnitude;
		animator.SetBool ("playerInRange", playerRange <= openRange);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
