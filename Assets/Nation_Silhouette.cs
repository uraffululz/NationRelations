using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nation_Silhouette : MonoBehaviour {

	Color natColor;


	void Awake () {
		//natColor = gameObject.GetComponentInParent<Nations> ().natColor;
		//natColor = gameObject.GetComponentInParent<MeshRenderer> ().material.color;

		//print (transform.parent.gameObject.name + ": " + gameObject.GetComponentInParent<MeshRenderer> ().material.color);

	}


	void Update () {
		//gameObject.GetComponent<MeshRenderer> ().material.color = natColor;

	}
}
