using UnityEngine;
using System.Collections;

public class Destroybyfalling : MonoBehaviour {

	void OnTriggerExit(Collider other){

		Destroy (other.gameObject);
	}

}
