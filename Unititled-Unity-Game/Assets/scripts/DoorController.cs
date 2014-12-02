using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {
	Animator animator;
	Transform door;
	Transform player;
	
	bool playerInRange = false;
	float openRange = 10.0f;

	// Use this for initialization
	void Start () {
		animator = GetComponent <Animator> ();
		door = transform;
		player = GameObject.Find("Player").transform;
	}
	
	void FixedUpdate () {
		float playerRange = Vector2.Scale(player.position - door.position, door.localScale).magnitude;
		
		if ((playerRange <= openRange) != playerInRange) {
			audio.Play();
			playerInRange = playerRange <= openRange;
		}
		
		animator.SetBool ("playerInRange", playerInRange);
	}
	
	void playSound () {
	}
}
