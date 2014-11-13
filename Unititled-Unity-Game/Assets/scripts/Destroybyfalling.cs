using UnityEngine;
using System.Collections;

public class Destroybyfalling : MonoBehaviour {

	void OnTriggerExit2D(Collider2D other){
		if (other.tag == "Player") {
						other.gameObject.SendMessage ("AdjustcurHealth", 250);
						Application.LoadLevel ("DeathScene");
				}
		else
		Destroy(other.gameObject);
	}

}
