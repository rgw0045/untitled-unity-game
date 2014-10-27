using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour {

	private int levelNum;

	void OnTriggerEnter2D(Collider2D other){
				if (other.tag == "Player") {
						int.TryParse (Application.loadedLevelName, out levelNum);
						levelNum += 1;
						Application.LoadLevel (levelNum);
				}
	
		}
}
