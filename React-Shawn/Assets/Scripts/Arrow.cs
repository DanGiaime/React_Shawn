using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

	public bool lit;
	public float lightProb;
	public KeyCode code;
	public GameObject gameManager;

	//Tiem until dark
	public float currTTL;
	public float permTTL;

	// Use this for initialization
	void Start () {
		this.permTTL = 1f;
		this.lit = false;
		this.gameManager = GameObject.Find ("gameManager");
	}
	
	// Update is called once per frame
	void Update () {
		currTTL -= Time.deltaTime;

		if (!this.lit) {
			float shouldLight = Random.Range (0f, 1f);
			if (shouldLight < this.lightProb) {
				this.lit = true;
			}
			if (Input.GetKeyDown (code)) {
				gameManager.GetComponent<GameManager> ().lives--;
			}
		} else if (lit && this.currTTL > 0) {
			if (Input.GetKeyDown (code)) {
				gameManager.GetComponent<GameManager> ().score++;
				lit = false;
				permTTL -= .01f;
			}
		} else if (lit && this.currTTL < 0) {
			gameManager.GetComponent<GameManager> ().lives--;
			this.lit = false;
			permTTL -= .01f;
		}
	}

}
