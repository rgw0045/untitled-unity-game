using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour {

	private int levelNum;
	private GameController gameController;

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

	void OnTriggerEnter2D(Collider2D other){
				if (other.tag == "Player") {
						gameController.TimeScore();
						int.TryParse (Application.loadedLevelName, out levelNum);
						levelNum += 1;
						Application.LoadLevel (levelNum);
				}
	
		}
}
