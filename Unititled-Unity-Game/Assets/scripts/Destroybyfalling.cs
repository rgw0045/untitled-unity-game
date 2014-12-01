using UnityEngine;
using System.Collections;

public class Destroybyfalling : MonoBehaviour {
	public GameObject displayTexts;
	public GameObject gameController;

	void OnTriggerExit2D(Collider2D other){
		if (other.tag == "Player") {
			Destroy(displayTexts);
			Destroy(gameController);
			Application.LoadLevel ("DeathScene");
				}
		else
		Destroy(other.gameObject);
	}

}
