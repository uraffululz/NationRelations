﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour {

	public LevelManager lvlManager;

	public int score = 0;

	float moveSpeed = 8.0f;
	float moveClampMin = -6.0f;
	float moveClampMax = 6.0f;

	void Start () {
		
	}
	

	void Update () {
		Movement ();
		Shrink ();
	}


	void OnCollisionEnter (Collision snatch) {
		if (snatch.gameObject.tag == "Debris") {
			score = score + (int) ((transform.localScale.y / snatch.gameObject.transform.localScale.y) / 2);
				print ("Score: " + score);
			CatchDebris ();
		}
	}


	void OnTriggerEnter (Collider grab) {
		if (grab.gameObject.tag == "Funding") {
			Destroy (grab.gameObject);
			CollectFunding ();
		} else if (grab.gameObject.tag == "WMD") {
			score = score + 10;
			print ("Score Increased: " + score);

			CatchWMD ();
		}
	}


	void Movement () {
		Vector3 shieldPos = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z);

		if (Input.GetKey(KeyCode.LeftArrow)) {
			shieldPos = shieldPos + (Vector3.left * moveSpeed * Time.deltaTime);
		} else if (Input.GetKey(KeyCode.RightArrow)) {
			shieldPos = shieldPos + (Vector3.right * moveSpeed * Time.deltaTime);
		}

		shieldPos.x = Mathf.Clamp (shieldPos.x, moveClampMin, moveClampMax);
		this.transform.position = shieldPos;
	}


	void Shrink () {
		float scaleDec = 0.01f * Time.deltaTime; //Return to about 0.02f
		transform.localScale -= new Vector3 (0.0f, scaleDec, 0.0f);
		moveClampMin -= scaleDec;
		moveClampMax += scaleDec;
		if (transform.localScale.y <= 0.0f) {
/*TODO
 * For now, print "Game Over" when player Shield shrinks to nothing.
 * Later on, maybe just load hidden canvas elements (Score text, along with score variables(Debris/WMDs caught, time lasted, etc.))
 * all while disabling visible objects in the (still active) Game scene in order to see score clearly.
 * Also include "Back to Start" button. */
			//lvlManager.LoadLevel ("GameOver");
			Time.timeScale = 0.0f;
			print ("Game Over");
		}
	}


	void CatchDebris () {
		
	}


	void CatchWMD () {
		print ("WMD stopped");
	}


	void CollectFunding () {
		float scaleInc = 0.15f;
		transform.localScale += new Vector3 (0.0f, scaleInc, 0.0f);
		moveClampMin += scaleInc;
		moveClampMax -= scaleInc;
		print ("Funding Acquired! Shield size increased!");
	}
}
