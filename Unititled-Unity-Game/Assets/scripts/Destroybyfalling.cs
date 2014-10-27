using UnityEngine;
using System.Collections;

public class Destroybyfalling : MonoBehaviour {

	void OnTriggerExit(Collider2D other){
		Destroy(other.gameObject);
	}

}
