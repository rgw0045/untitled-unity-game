using UnityEngine;
using System.Collections;

public class KillBullets : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){

		if (other.tag == "PLayerBullet" || other.tag == "EnemyBullet")
		  Destroy (other.gameObject);
	}

	
}
