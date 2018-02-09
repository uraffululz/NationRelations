using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour {


	void Start () {
		
	}
	

	void Update () {
		
	}


	public void LoadLevel (string name) {
		SceneManager.LoadScene (name);
	}
}
