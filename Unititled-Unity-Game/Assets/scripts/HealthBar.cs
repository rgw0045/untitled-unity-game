using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {
	public static int maxHealth = 250;
	public static int curHealth = 250;
	private float healthBarLenght;
	private GUIStyle HealthBarStyle = null;
	private GUIStyle HealthBoxStyle = null;


	// Use this for initialization
	void Start () {
		healthBarLenght = Screen.width / 4;
	}
	
	// Update is called once per frame
	void Update () {
		AdjustcurHealth (0);
	}

	//make the box for the health bar
	void OnGUI() {
		InitStyle ();
		GUI.Box (new Rect (5, 5, (Screen.width / 4)+10, 45), "Health", HealthBoxStyle);
		GUI.Box (new Rect(10, 25, healthBarLenght, 20),"", HealthBarStyle);
	}

	private void InitStyle() {
		  if (HealthBarStyle == null) {
			HealthBarStyle = new GUIStyle( GUI.skin.box);
			HealthBarStyle.normal.background = MakeTex(2,2,new Color ( 0.0f, 0.4f, 0.0f, 0.5f));
		  }
		if (HealthBoxStyle == null) {
			HealthBoxStyle = new GUIStyle(GUI.skin.box);
			HealthBoxStyle.normal.background = MakeTex (2,2,new Color(0.0f,0.0f,0.0f,1.0f));
		}
	}

	private Texture2D MakeTex(int width, int height, Color col) {
		Color[] pix = new Color[width * height];
		for (int i = 0; i < pix.Length; ++i) {
			pix[i] = col;
		}
		Texture2D result = new Texture2D (width, height);
		result.SetPixels(pix);
		result.Apply ();
		return result;
	}

	public void AdjustcurHealth(int adj) {
		curHealth += adj;

		if (curHealth < 0) {
			curHealth = 0;
			Application.LoadLevel ("DeathScene");
		}
		if (curHealth > maxHealth)
			curHealth = maxHealth;
		if (maxHealth < 1)
			maxHealth = 1;

		healthBarLenght = (Screen.width / 4) * (curHealth / (float)maxHealth);
	}
}
