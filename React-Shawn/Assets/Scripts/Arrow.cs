using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

	public bool lit;
	public float lightProb;
	public KeyCode code;
	public GameObject gameManager;
	public Sprite litSprite;
	public Sprite darkSprite;
	private AudioSource audio;

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
		this.audio = this.GetComponent<AudioSource> ();
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
					Click ();

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
					Boom ();
				}
			} 

			//Missed, sucks, kill em.
			else if (lit && this.currTTL < 0) {
				gameManager.GetComponent<GameManager> ().lives--;
				this.lit = false;
				this.GetComponent<SpriteRenderer> ().sprite = darkSprite;
				permTTL -= .1f;
				currTTL = 0;
				Click ();
			}
		}
	}

	void Click() {
		audio.clip = gameManager.GetComponent<GameManager> ().CLICK;
		audio.time = .7f;
		audio.Play ();
	}

	void Boom () {
		audio.clip = gameManager.GetComponent<GameManager> ().BOOM;
		audio.time = .7f;
		audio.Play ();
	}

}
