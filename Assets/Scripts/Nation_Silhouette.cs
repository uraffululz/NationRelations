using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nation_Silhouette : MonoBehaviour {

	Color natColor;

	Vector3 natScale;

	public Mesh[] chooseMesh;
	Mesh chosenMesh;

	void Awake () {
		natScale = gameObject.GetComponentInParent<Nations> ().natScale;
		chosenMesh = chooseMesh [Random.Range (0, chooseMesh.Length)];
		gameObject.GetComponent<MeshFilter> ().mesh = chosenMesh;

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
