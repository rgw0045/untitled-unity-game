﻿using UnityEngine;
using System.Collections;

public class BacktoMainMenuLeft : MonoBehaviour {

	private int levelNum;

	void OnTriggerEnter2D(Collider2D other){
				if (other.tag == "Player") {
						Application.LoadLevel ("BacktoMainMenuLeft");
				}
	
		}
}