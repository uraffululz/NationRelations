using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nations : MonoBehaviour {

	public GameObject[] nations;

	//public Color[] colors = new Color[] {Color.blue, Color.green, Color.yellow, Color.red};
	public List<Color> colors = new List<Color> {Color.blue, Color.green, Color.yellow, Color.red};
	public Color colorSet;


	void Awake () {
		nations = GameObject.FindGameObjectsWithTag ("Nation");
		ChooseColor ();
	}


	void Start () {
		
	}
	

	void Update () {
		
	}


	void ChooseColor () {
		foreach (var nation in nations) {
			colorSet = colors [Random.Range (0, colors.Count)];
			nation.gameObject.GetComponent<MeshRenderer> ().material.color = colorSet;
			colors.Remove (colorSet);
		}
	}
}
