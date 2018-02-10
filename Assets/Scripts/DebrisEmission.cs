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
		timerStart = 0.5f;
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
		Vector2 spawnPos = new Vector2 (Random.Range (-6.0f, 6.0f), 11.0f);
/*TODO MAYBE Change velocity to be relative to spawn position, adding positive x-plane velocity to those in the negative x-space,
and negative velocity to those in positive x-space*/
		//Vector2 spawnVel = new Vector2 (Random.Range (-1.3f * spawnPos.x, 0.5f / spawnPos.x), 0.0f);
		Vector3 spawnRot = new Vector3 (Random.Range (0.0f, 10.0f), Random.Range (0.0f, 2.0f), Random.Range (0.0f, 10.0f));

		//print ("Position: " + spawnPos);
		//print ("Velocity: " + spawnVel);

		debrisClone = Instantiate (debris, spawnPos, Quaternion.identity, gameObject.transform);
		Rigidbody debRB = debrisClone.GetComponent<Rigidbody> ();
		//debRB.AddForce (spawnVel);
		debRB.AddTorque (spawnRot);
	}
}
