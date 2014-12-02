using UnityEngine;
using System.Collections;

public class DoorOminousLeft : MonoBehaviour {

	private int levelNum;

	void OnTriggerEnter2D(Collider2D other){
				if (other.tag == "Player") {
						Application.LoadLevel ("OminousLeft");
				}
	
		}
}
