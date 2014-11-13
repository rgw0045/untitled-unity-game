using UnityEngine;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {

	public GameObject player;
	public GUIText scoreText;
	private int score;

	void Start(){

		DontDestroyOnLoad (player);
		score = 0;
		UpdateScore ();
	}

	public void Addscore(int modifier){

		score += modifier;
		UpdateScore ();
	}

	void UpdateScore(){

		scoreText.text = "Score: " + score;
	}

}
