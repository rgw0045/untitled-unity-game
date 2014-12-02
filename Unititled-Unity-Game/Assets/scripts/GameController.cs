﻿using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject controller;
	public GUIText scoreText;
	public GUIText timeText;
	private int score;
	private float startTime;
	private float stageTime;
	
	void Start(){
		//GameObject displayText = GameObject.Find ("Display Text");
		scoreText = GameObject.Find ("/Display Text/Score Text").GetComponent<GUIText>();
		timeText = GameObject.Find ("/Display Text/TIme Text").GetComponent<GUIText>();
		DontDestroyOnLoad (controller);
		score = 0;
		startTime = Time.time;
		UpdateScore ();
		timeText.text = "Time: " + stageTime;
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


}
