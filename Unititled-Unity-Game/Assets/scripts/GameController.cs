using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject player;
	public GUIText scoreText;
	public GUIText timeText;
	private static int score;
	private float startTime;
	private float stageTime;
	
	void Start(){
		
		//DontDestroyOnLoad (GameController);
		score = 0;
		startTime = Time.time;
		UpdateScore ();

	}

	void Update(){
		stageTime = Time.time - startTime;
		timeText.text = "Time: " + stageTime;
	
	}
	
	public void Addscore(int modifier){
		
		score += modifier;
		UpdateScore ();
	}
	
	void UpdateScore(){
		scoreText.text = "Score: " + score;
	}

	public void TimeScore(){
		int reward;

		if (stageTime <= 20) {
			reward = 70;
			Addscore(reward);
		}

		if (stageTime <= 30 && stageTime > 20) {
			reward = 50;
			Addscore(reward);
		}

		if (stageTime <= 50 && stageTime > 30) {
			reward = 20;
			Addscore(reward);
		}

		if (stageTime > 50) {
			reward = 10;
			Addscore(reward);
		}

	}

}
