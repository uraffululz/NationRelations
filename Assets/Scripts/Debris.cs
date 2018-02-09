using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debris : MonoBehaviour {

	public GameObject explosion;

	void Start () {
		
	}
	

	void Update () {
		
	}


	void OnCollisionEnter (Collision other) {
		if (other.gameObject.CompareTag("Nation")) {
			
		}

		explosion = Instantiate (explosion, transform.position, Quaternion.identity);
		Destroy (gameObject);
	}
}
