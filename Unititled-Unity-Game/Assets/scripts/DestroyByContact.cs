using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	GameObject displayText;
	GameObject gameController;
	
	void Start(){
		gameController = GameObject.Find ("GameController");
		displayText = GameObject.Find ("Display Text");
	
	}
	void OnTriggerEnter2D(Collider2D other) {

		if (other.tag == "Player") {
			Destroy(displayText);
			Destroy(gameController);
			Application.LoadLevel("DeathScene");
		}
	}

}
