using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject player;
	public GUIText scoreText;
	public GUIText timeText;
	private int score;
	private float startTime;
	private float stageTime;
	
	void Start(){
		
		//DontDestroyOnLoad (player);
		score = 0;
		startTime = Time.time;
		UpdateScore ();
		UpdateTime ();
	}

	void Update(){

		stageTime = Time.time - stageTime;
		UpdateTime ();
	}
	
	public void Addscore(int modifier){
		
		score += modifier;
		UpdateScore ();
	}
	
	void UpdateScore(){
		
		scoreText.text = "Score: " + score;
	}

	void UpdateTime(){

		timeText.text = "Time: " + stageTime;
	}
}
