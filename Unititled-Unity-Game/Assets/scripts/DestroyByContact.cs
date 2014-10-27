using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	/*public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	private gameController;

	void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag("GameController");
		if (gameControllerObject != null) 
		{
			gameController = gameControllerObject.GetComponent<GameController>();		
		}

		if (gameController == null) 
		{
			Debug.Log("Cannot Find 'GameController' Script!");		
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Boundary") {
			return;		
		}
		Instantiate (explosion, transform.position, transform.rotation);
		if (other.tag == "Player") {
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
		}
		Destroy(other.gameObject);
		Destroy(gameObject);
	}*/

}
