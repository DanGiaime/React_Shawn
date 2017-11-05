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
		this.score = 0;
		this.lives = 0;

		//make arrow objects
		GameObject left = Instantiate (leftArrow, transform);
		Arrow leftA = left.GetComponent<Arrow> ();
		leftA.code = KeyCode.LeftArrow;


		GameObject right = Instantiate (rightArrow, transform);
		Arrow rightA = right.GetComponent<Arrow> ();
		rightA.code = KeyCode.RightArrow;


		GameObject up = Instantiate (upArrow, transform);
		Arrow upA = up.GetComponent<Arrow> ();
		upA.code = KeyCode.UpArrow;


		GameObject down = Instantiate (downArrow, transform);
		Arrow downA = down.GetComponent<Arrow> ();
		downA.code = KeyCode.DownArrow;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
