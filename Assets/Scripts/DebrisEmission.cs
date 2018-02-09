using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebrisEmission : MonoBehaviour {

	public GameObject[] debrisFabs;
	public GameObject debris;
	private GameObject debrisClone;

	public float timerStart;
	public float timer;


	void Start () {
		timerStart = 2.0f;
		timer = timerStart;
	}
	

	void Update () {
		if (timer > 0.0f) {
			timer = timer - Time.deltaTime;
		} else {
			FireDebris ();
			timer = timerStart;
		}
	}


	void FireDebris () {
		debris = debrisFabs [Random.Range (0, debrisFabs.Length)];
		Vector2 spawnPos = new Vector2 (Random.Range (1.5f, 14.5f), 12.0f);
		//Vector2 spawnVel = new Vector2 (Random.Range (-1.0f, 0.0f), Random.Range (-1.0f, 0.0f));
		Vector3 spawnRot = new Vector3 (Random.Range (0.0f, 10.0f), Random.Range (0.0f, 2.0f), Random.Range (0.0f, 10.0f));

		debrisClone = Instantiate (debris, spawnPos, Quaternion.identity, gameObject.transform);
		debrisClone.GetComponent<Rigidbody> ().AddTorque (spawnRot);
	}
}
