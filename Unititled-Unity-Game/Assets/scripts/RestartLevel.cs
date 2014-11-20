using UnityEngine;
using System.Collections;

public class RestartLevel : MonoBehaviour {

	void Start() {
		audio.Play ();
	}

   void OnGUI() {
		GUI.Box (new Rect (Screen.width / 2, Screen.height / 2, 100, 90), "Restart");

		if (GUI.Button (new Rect ((Screen.width / 2) + 10, (Screen.height / 2) + 30, 80, 20), "First Level")) {
			HealthBar.curHealth = HealthBar.maxHealth;
			Application.LoadLevel (1);
		}
		if(GUI.Button (new Rect((Screen.width/2)+10, (Screen.height/2)+60, 80, 20), "Exit"))
			Application.Quit();
	}
}
