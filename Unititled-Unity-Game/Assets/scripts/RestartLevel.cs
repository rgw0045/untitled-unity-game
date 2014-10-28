using UnityEngine;
using System.Collections;

public class RestartLevel : MonoBehaviour {

   void OnGUI() {
		GUI.Box (new Rect (Screen.width / 2, Screen.height / 2, 100, 90), "Restart");

		if(GUI.Button (new Rect((Screen.width/2)+10, (Screen.height/2)+30, 80, 20), "First Level"))
		               Application.LoadLevel(1);
		if(GUI.Button (new Rect((Screen.width/2)+10, (Screen.height/2)+60, 80, 20), "Exit"))
			Application.Quit();
	}
}
