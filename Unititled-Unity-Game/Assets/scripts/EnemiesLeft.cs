using UnityEngine;
using System.Collections;

public class EnemiesLeft : MonoBehaviour {

	int enemiesLeft = 0;
	bool killedAllEnemies = false;

	// Use this for initialization
	void Start () {
		enemiesLeft = 2;
	}
	
	// Update is called once per frame
	void Update () {
		GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy");
		enemiesLeft = enemies.Length;
		if (enemiesLeft == 0) {
			Application.LoadLevel("WinScene");
	    }
	}
}
