using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public float score;
	public int lives;
	public GameObject leftArrow;
	public GameObject rightArrow;
	public GameObject upArrow;
	public GameObject downArrow;

	// Use this for initialization
	void Start () {

		//make arrow objects
		Instantiate (leftArrow, transform);
		Instantiate (rightArrow, transform);
		Instantiate (upArrow, transform);
		Instantiate (downArrow, transform);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
