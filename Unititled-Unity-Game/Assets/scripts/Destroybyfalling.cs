using UnityEngine;
using System.Collections;

public class DestroybyFalling : MonoBehaviour {

	void OnTriggerExit2D(Collider2D other){
		if (other.tag == "Player") 
			Application.LoadLevel ("DeathScene");
		else
		Destroy(other.gameObject);
	}

}
