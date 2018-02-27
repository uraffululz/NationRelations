using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupEmitter : MonoBehaviour {

	GameObject[] nationArray;
	public List<GameObject> nationList;

	public GameObject[] debrisFabs;
	public GameObject debris;
	private GameObject debrisClone;
	public float debTimeStart;
	public float debTimer;

	public GameObject[] fundFabs;
	public GameObject funding;
	private GameObject fundClone;
	//public float fundTimeStart;
	public float fundTimer;

	void Awake () {
		nationArray = GameObject.FindGameObjectsWithTag ("Nation");
		nationList = new List<GameObject> {nationArray[0], nationArray[1],nationArray[2],nationArray[3]};
	}
		

	void Start () {
		debTimeStart = 1.0f;
		debTimer = debTimeStart;

		fundTimer = 20.0f/nationList.Count;
	}
	

	void Update () {
		if (debTimer > 0.0f) {
			debTimer = debTimer - Time.deltaTime;
		} else {
			FireDebris ();
			debTimer = Random.Range (1.0f, 2.0f);
		}

		if (fundTimer > 0.0f) {
			fundTimer -= Time.deltaTime;
		} else {
			SendFunding ();
			fundTimer = 20.0f/nationList.Count;
		}
	}


	void FireDebris () {
		debris = debrisFabs [Random.Range (0, debrisFabs.Length)];
		Vector3 debPos = new Vector3 (Random.Range (-6.0f, 6.0f), 11.0f, 0.0f);
/*TODO MAYBE Change velocity to be relative to spawn position, adding positive x-plane velocity to those in the negative x-space,
and negative velocity to those in positive x-space*/
		//Vector3 debVel = new Vector3 (Random.Range (-13.0f * debPos.x, 5.0f / debPos.x), 0.0f, 0.0f);
		Vector3 debRot = new Vector3 (Random.Range (0.0f, 10.0f), Random.Range (0.0f, 2.0f), Random.Range (0.0f, 10.0f));

		//print ("Position: " + debPos);
		//print ("Velocity: " + debVel);

		debrisClone = Instantiate (debris, debPos, Quaternion.identity, gameObject.transform);
		float debScale = Random.Range (0.1f, 0.4f);
		debrisClone.transform.localScale = new Vector3 (debScale, debScale, debScale);
		Rigidbody debRB = debrisClone.GetComponent<Rigidbody> ();
		//debRB.AddForce (debVel);
		debRB.AddTorque (debRot);
	}


	void SendFunding () {
		funding = fundFabs [Random.Range (0, fundFabs.Length)];
		Transform chooseFundingSpawnNation = nationList[Random.Range (0, nationList.Count)].transform;
		float spotWithinNation = Random.Range (-1.1f, 1.1f);
		Vector3 fundPos = new Vector3 (chooseFundingSpawnNation.position.x + spotWithinNation, 1.5f, 0.0f);
		Vector3 fundRot = new Vector3 (0.0f, 150.0f, 0.0f);
		Vector3 fundVel = new Vector3 (0.0f, 80.0f, 0.0f);
/*TODO Manipulate values for fundVel^ and fundTimer^^, along with Funding prefab Rigidbody component (mass, drag, etc.) in the Editor
 * Also, the Shrink rate on the Shield script is a factor, along with its moveSpeed.
 * Repeat until it feels good (which I guess means until it feels intense, but generous, and fun)*/

		fundClone = Instantiate (funding, fundPos, Quaternion.identity, gameObject.transform);
		Rigidbody fundRB = fundClone.GetComponent<Rigidbody> ();
		fundRB.AddForce (fundVel);
		fundRB.AddTorque (fundRot);
	}
}
