using UnityEngine;
using System.Collections;

public class RestartLevel : MonoBehaviour {

   void OnGUI() {
		GUI.Box (new Rect (Screen.width / 2, Screen.height / 2 - 30, 100, 120), "Death");

		if (GUI.Button (new Rect ((Screen.width / 2) + 10, (Screen.height / 2) + 0, 80, 20), "Menu")) {
			HealthBar.curHealth = HealthBar.maxHealth;
			Application.LoadLevel ("Title_Menu");
		}

		if (GUI.Button (new Rect ((Screen.width / 2) + 10, (Screen.height / 2) + 30, 80, 20), "First Level")) {
			HealthBar.curHealth = HealthBar.maxHealth;
			Application.LoadLevel (1);
		}
		if(GUI.Button (new Rect((Screen.width/2)+10, (Screen.height/2)+60, 80, 20), "Exit"))
			Application.Quit();
	}
}
