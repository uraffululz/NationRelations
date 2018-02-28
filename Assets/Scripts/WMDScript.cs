using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WMDScript : MonoBehaviour {

	public GameObject WMDExplosion;


	void Start () {
		
	}
	

	void Update () {
/*TODO: Finish this (WMD rotation) after modeling the WMD. It will be easier to get a visual reference for rotation then*/
		if (gameObject.GetComponent<Rigidbody> ().velocity.y < 0.0f) {
			Vector3 lookRot = new Vector3 (transform.position.x, transform.position.y - 1.0f, 0.0f);
			if (gameObject.GetComponent<Rigidbody>().velocity.x < 0.0f) {
				transform.rotation = Quaternion.LookRotation (lookRot, Vector3.left);
			} else {
				transform.rotation = Quaternion.LookRotation (lookRot, Vector3.right);
			}
		}
	}


	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Shield" || other.gameObject.tag == "Nation"
			|| other.gameObject.tag == "WMD" || other.gameObject.tag == "Debris") {
			WMDExplosion = Instantiate (WMDExplosion, transform.position, Quaternion.identity);
			Destroy (gameObject);
		}
	}
}
