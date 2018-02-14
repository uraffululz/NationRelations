using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nations : MonoBehaviour {

	Color natColor;

	void Awake () {
		
	}


	void Start () {
		natColor = gameObject.GetComponent<MeshRenderer> ().material.color;
	}
	

	void Update () {
		
	}


	void OnCollisionEnter (Collision deb) {
		Color debColor = deb.gameObject.GetComponent<MeshRenderer>().material.color;
		if (debColor == natColor) {
			print ("Nation attacked itself");
		} else {
			print (natColor + " nation attacked by " + debColor + " nation"); 
		}
	}
}
