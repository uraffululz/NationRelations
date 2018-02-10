using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour {

	public LevelManager lvlManager;

	public int score = 0;

	float moveSpeed = 7.5f;

	void Start () {
		
	}
	

	void Update () {
		Movement ();
		Shrink ();
	}


	void OnCollisionEnter (Collision snatch) {
		if (snatch.gameObject.tag == "Debris") {
			CatchDebris ();
		}
	}


	void OnTriggerEnter (Collider grab) {
		if (grab.gameObject.tag == "Funding") {
			Destroy (grab.gameObject);
			CollectFunding ();
		}
	}


	void Movement () {
		Vector3 shieldPos = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z);

		if (Input.GetKey(KeyCode.LeftArrow)) {
			shieldPos = shieldPos + (Vector3.left * moveSpeed * Time.deltaTime);
		} else if (Input.GetKey(KeyCode.RightArrow)) {
			shieldPos = shieldPos + (Vector3.right * moveSpeed * Time.deltaTime);
		}

		shieldPos.x = Mathf.Clamp (shieldPos.x, -6.0f, 6.0f);
		this.transform.position = shieldPos;
	}


	void Shrink () {
		transform.localScale -= new Vector3 (0.0f, 0.05f * Time.deltaTime, 0.0f);
		if (transform.localScale.y <= 0.0f) {
/*TODO
 * For now, load "GameOver" scene when player Shield shrinks to nothing.
 * Later on, maybe just load hidden canvas elements (Score text, along with score variables(Debris/WMDs caught, time lasted, etc.))
 * all while disabling visible objects in the (still active) Game scene in order to see score clearly.
 * Also include "Back to Start" button. */
			lvlManager.LoadLevel ("GameOver");
		}
	}


	void CatchDebris () {
		score++;
		print ("Score increased");
	}


	void CollectFunding () {
		transform.localScale += new Vector3 (0.0f, 0.1f, 0.0f);
		print ("Funding Acquired! Shield size increased!");
	}
}
