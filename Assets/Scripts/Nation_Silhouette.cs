using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nation_Silhouette : MonoBehaviour {

	Color natColor;

	Vector3 natScale;

	void Awake () {
		natScale = gameObject.GetComponentInParent<Nations> ().natScale;
		//natColor = gameObject.GetComponentInParent<MeshRenderer> ().material.color;

		//print (transform.parent.gameObject.name + ": " + gameObject.GetComponentInParent<MeshRenderer> ().material.color);

	}


	void Update () {
		natScale = gameObject.GetComponentInParent<Nations> ().natScale;
		if (transform.localScale != natScale) {
			transform.localScale = natScale;
		}
	}
}
