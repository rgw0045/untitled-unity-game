using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	public Texture backgroundTexture;

	//Display Background
	void OnGUI()
	{
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), backgroundTexture);


	//GUI button

		if(GUI.Button (new Rect(Screen.width * .25f, Screen.height *.35f, Screen.width *.5f, Screen.height *.1f), "Play"))
		{
			Application.LoadLevel(1);
			//debug
			print("Clicked Play");
		}
		if(GUI.Button (new Rect(Screen.width * .25f, Screen.height *.75f, Screen.width *.5f, Screen.height *.1f), "Exit"))
		{
			Application.Quit();
			//debug
			print("Clicked Exit");
		}
	}
}
		                    