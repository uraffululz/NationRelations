using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WMDScript : MonoBehaviour {

	public GameObject WMDExplosion;


	void Start () {
		
	}
	

	void Update () {
		
	}


	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Shield" || other.gameObject.tag == "Nation" || other.gameObject.tag == "WMD") {
			WMDExplosion = Instantiate (WMDExplosion, transform.position, Quaternion.identity);
			Destroy (gameObject);
		}
	}
}
