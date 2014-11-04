using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {
	private static int maxHealth = 500;
	public int curHealth = 250;
	private float healthBarLenght;
	private GUIStyle currentStyle = null;


	// Use this for initialization
	void Start () {
		healthBarLenght = Screen.width / 2;
	}
	
	// Update is called once per frame
	void Update () {
		AdjustcurHealth (0);
	}

	//make the box for the health bar
	void OnGUI() {
		InitStyle ();
		GUI.Box (new Rect(10, 10, healthBarLenght, 20), "curHealth", currentStyle);
	}

	private void InitStyle() {
		  if (currentStyle == null) {
			currentStyle = new GUIStyle( GUI.skin.box);
			currentStyle.normal.background = MakeTex(2,2,new Color ( 0.0f, 0.4f, 0.0f, 0.5f));
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

		healthBarLenght = (Screen.width / 2) * (curHealth / (float)maxHealth);
	}
}
