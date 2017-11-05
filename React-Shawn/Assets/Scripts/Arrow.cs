﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

	public bool lit;
	public float lightProb;
	public KeyCode code;
	public GameObject gameManager;
	public Sprite litSprite;
	public Sprite darkSprite;

	//Tiem until dark
	public float currTTL;
	public float permTTL;

	// Use this for initialization
	void Start () {
		this.permTTL = 5f;
		this.lit = false;
		this.lightProb = .01f;
		this.currTTL = 0;
		this.gameManager = GameObject.Find ("GameManager");
		this.GetComponent<SpriteRenderer> ().sprite = darkSprite;
	}
	
	// Update is called once per frame
	void Update () {
		if (gameManager.GetComponent<GameManager> ().lives > 0) {
			currTTL -= Time.deltaTime;

			//Not lit, check if should light
			if (!this.lit) {
				float shouldLight = Random.Range (0f, 1f);
				if (shouldLight < this.lightProb) {
					this.lit = true;
					this.currTTL = permTTL;
					this.GetComponent<SpriteRenderer> ().sprite = litSprite;
				}
				if (Input.GetKeyDown (code)) {
					gameManager.GetComponent<GameManager> ().lives--;
					Debug.Log ("LIVES: " + gameManager.GetComponent<GameManager> ().lives);

				}
			} 

			//lit, check if clicked correctly
			else if (lit && this.currTTL > 0) {
				if (Input.GetKeyDown (code)) {
					gameManager.GetComponent<GameManager> ().score++;
					this.lit = false;
					this.GetComponent<SpriteRenderer> ().sprite = darkSprite;
					permTTL -= .05f;
					currTTL = 0;
					//this.lightProb += .001f;
					Debug.Log (gameManager.GetComponent<GameManager> ().score);
				}
			} 

			//Missed, sucks, kill em.
			else if (lit && this.currTTL < 0) {
				gameManager.GetComponent<GameManager> ().lives--;
				this.lit = false;
				this.GetComponent<SpriteRenderer> ().sprite = darkSprite;
				permTTL -= .1f;
				currTTL = 0;
			}
		}
	}

}
