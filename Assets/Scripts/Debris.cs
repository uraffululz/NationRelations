using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debris : MonoBehaviour {

	public GameObject explosion;

	public Color[] debColors = new Color[] {Color.blue, Color.green, Color.yellow, Color.red};
	public Color myColor;


	void Awake () {
		ApplyColor ();
	}


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


	void ApplyColor () {
		myColor = debColors [Random.Range (0, debColors.Length)];
		gameObject.GetComponent<MeshRenderer> ().material.color = myColor;
	}
}
