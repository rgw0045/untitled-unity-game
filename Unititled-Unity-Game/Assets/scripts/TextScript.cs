using UnityEngine;
using System.Collections;

public class TextScript : MonoBehaviour {

	public GameObject displayTexts;
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (displayTexts);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
