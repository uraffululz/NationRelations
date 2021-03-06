﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debris : MonoBehaviour {

	public GameObject explosion;

	public GameObject[] nationArray;
	public List<GameObject> nationList;
	//List<Color> colorList;
	//public Color[] debColors = new Color[] {Color.blue, Color.green, Color.yellow, Color.red};
	public Color myColor;


	void Awake () {
		nationArray = GameObject.FindGameObjectsWithTag ("Nation");
		nationList = new List<GameObject> {};

		foreach (var nation in nationArray) {
			if (nation.gameObject.GetComponent<MeshRenderer>().material.color != Color.black) {
				nationList.Add (nation);
			}
		}
		//nationList.AddRange (nationArray);
		ApplyColor ();
	}


	void Start () {
		
	}
	

	void Update () {
		
	}


	void OnCollisionEnter (Collision other) {
		explosion = Instantiate (explosion, transform.position, Quaternion.identity);
		Destroy (gameObject);
	}


	void ApplyColor () {
		int colorCount = Random.Range (0, nationList.Count);
		gameObject.GetComponent<MeshRenderer>().material.color = nationList[colorCount].GetComponent<MeshRenderer> ().material.color;

	}
}
