﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nations : MonoBehaviour {

	public GameObject Emitter;

	Color natColor;
	List<Color> natChildcolors = new List<Color> {Color.blue, Color.green, Color.yellow, Color.red};
	SpriteRenderer[] childSprites;
	MeshRenderer[] childRenderers;

	public GameObject[] natArray;
	public List<Color> natColorList = new List<Color> {};

	public int natHP = 100;
	public Vector3 natScale;

	public GameObject WMD;
	GameObject WMDClone;


	void Awake () {
		natScale = new Vector3 (0.3f, 2.0f, 1.0f);
	}


	void Start () {
		natColor = gameObject.GetComponent<MeshRenderer> ().material.color;
		SetChildColors ();

		natArray = gameObject.GetComponentInParent<NationParent> ().nations;
	}
	

	void Update () {
		
	}


	void OnCollisionEnter (Collision deb) {
		Color debColor = deb.gameObject.GetComponent<MeshRenderer>().material.color;
		if (debColor != natColor) {
			natHP = natHP - 10;
			if (natHP <= 0) {
				NationRevivalCol (deb);
			} else {
				natScale = new Vector3 (0.3f, (natHP/100.0f) * 2, 1.0f);
				foreach (SpriteRenderer sprite in childSprites) {
					Vector3 spriteScale = sprite.gameObject.transform.localScale;
					Vector3 spriteShrink = new Vector3 (-0.5f / 3.25f, -0.5f / 0.5f, -0.5f / 1.0f);

					if (debColor == sprite.color) {
						sprite.gameObject.transform.localScale += spriteShrink;

						if (sprite.gameObject.transform.localScale.y <= 0.0f) {
							foreach (var nation in gameObject.GetComponentInParent<NationParent>().nations) {
								if (nation != null) {
									if (nation.GetComponent<MeshRenderer> ().material.color == debColor) {
										print (gameObject.name + "launching WMD at " + nation);

										WMDClone = Instantiate (WMD, gameObject.transform.position + Vector3.up, Quaternion.identity);
										WMDClone.GetComponent<MeshRenderer> ().material.color = natColor;
										Rigidbody WMDRB = WMDClone.GetComponent<Rigidbody> ();

//Adding sideways velocity to WMDClone to attempt to "aim" it at the offending nation
										Vector3 WMDVel = new Vector3 ((nation.transform.position.x - gameObject.transform.position.x) * 1.5f, 80.0f, 0.0f);
										WMDRB.AddForce (WMDVel);
									}
								}
							}
						}
					}
				}
			}
		}
	}


	void OnTriggerEnter (Collider grab) {
		if (grab.gameObject.tag == "WMD") {
			Color grabColor = grab.gameObject.GetComponent<MeshRenderer>().material.color;
			if (grabColor != natColor) {
				natHP = natHP - 20;
				if (natHP <= 0) {
					NationRevivalTrig (grab);
				} else {
					natScale = new Vector3 (0.3f, (natHP/100.0f) * 2, 1.0f);
					foreach (SpriteRenderer sprite in childSprites) {
						Vector3 spriteScale = sprite.gameObject.transform.localScale;
						Vector3 spriteShrink = new Vector3 (-1.0f / 3.25f, -1.0f / 0.5f, -1.0f / 1.0f);
						if (grabColor == sprite.color) {
							sprite.gameObject.transform.localScale += spriteShrink;

							if (sprite.gameObject.transform.localScale.y <= 0.0f) {
								foreach (var nation in gameObject.GetComponentInParent<NationParent>().nations) {
									if (nation != null) {
										if (nation.GetComponent<MeshRenderer> ().material.color == grabColor) {
											print (gameObject.name + "launching WMD at " + nation);

											WMDClone = Instantiate (WMD, gameObject.transform.position + Vector3.up, Quaternion.identity);
											WMDClone.GetComponent<MeshRenderer> ().material.color = natColor;
											Rigidbody WMDRB = WMDClone.GetComponent<Rigidbody> ();

											//Adding sideways velocity to WMDClone to attempt to "aim" it at the offending nation
											Vector3 WMDVel = new Vector3 ((nation.transform.position.x - gameObject.transform.position.x) * 1.5f, 80.0f, 0.0f);
											WMDRB.AddForce (WMDVel);
										}
									}
								}
							}
						}
					}
				}
			}
		} else if (grab.gameObject.tag == "Funding") {
			Destroy (grab.gameObject);
		}
	}


	void SetChildColors () {
		childSprites = gameObject.GetComponentsInChildren<SpriteRenderer>();
		natChildcolors.Remove (natColor);

		foreach (SpriteRenderer childSprite in childSprites) {
			childSprite.color = natChildcolors [0];
			natChildcolors.RemoveAt (0);
		}

		childRenderers = gameObject.GetComponentsInChildren<MeshRenderer> ();
		foreach (MeshRenderer renderer in childRenderers) {
			renderer.material.color = natColor;
		}
	}


	void LaunchWMDs () {
/*		foreach (var nation in gameObject.GetComponentInParent<NationParent>().nations) {
			if (nation.GetComponent<MeshRenderer>().material.color == ) {
				
			}
		}
*/
	}


	void WMDStrike () {
		
	}


	void NationRevivalCol (Collision debCol) {
		natHP = 100;
		natColor = debCol.gameObject.GetComponent<MeshRenderer> ().material.color;
		gameObject.GetComponent<MeshRenderer> ().material.color = natColor;

		foreach (GameObject nat in natArray) {
			//Color natShade = gameObject.GetComponent<MeshRenderer> ().material.color;
			natColorList.Add (nat.GetComponent<MeshRenderer>().material.color);
		}
		if (natColorList.TrueForAll (LastNationStanding)) {
			GameObject.FindGameObjectWithTag ("Shield").GetComponent<Shield> ().GameOver ();
		};

		natColorList.Clear ();
			
		//natMatColorArray = new Color[] {};
		/*Emitter.GetComponent<PickupEmitter> ().nationList.Remove (gameObject);
		debCol.gameObject.GetComponent<Debris> ().nationList.Remove (gameObject);
		Destroy (gameObject);
*/
	}


	void NationRevivalTrig (Collider trigCol) {
		natHP = 100;
		natColor = trigCol.gameObject.GetComponent<MeshRenderer> ().material.color;
		gameObject.GetComponent<MeshRenderer> ().material.color = natColor;

		foreach (GameObject nat in natArray) {
			//Color natShade = gameObject.GetComponent<MeshRenderer> ().material.color;
			natColorList.Add (nat.GetComponent<MeshRenderer>().material.color);
		}
		if (natColorList.TrueForAll (LastNationStanding)) {
			GameObject.FindGameObjectWithTag ("Shield").GetComponent<Shield> ().GameOver ();
		};

		natColorList.Clear ();

		//Emitter.GetComponent<PickupEmitter> ().nationList.Remove (gameObject);
		//Destroy (gameObject);
	}


	bool LastNationStanding (Color matColor) {
		int colorCount = 0;

		foreach (Color color in natColorList) {
			if (color == natColor) {
				colorCount++;
			} else {
				colorCount--;
			}
		}
		if (colorCount == natColorList.Count) {
			return true;
		} else {
			return false;
		}
		/*if (gameObject.GetComponent<MeshRenderer> ().material.color == natColor) {
			return true;
		} else {
			return false;
		}*/
	}
}