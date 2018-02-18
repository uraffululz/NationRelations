using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nations : MonoBehaviour {

	public GameObject Emitter;

	Color natColor;
	List<Color> natChildcolors = new List<Color> {Color.blue, Color.green, Color.yellow, Color.red};
	SpriteRenderer[] childSprites;

	public int natHP = 100;

	//bool nationHostile = false;


	public GameObject WMD;
	GameObject WMDClone;


	void Awake () {
		
	}


	void Start () {
		natColor = gameObject.GetComponent<MeshRenderer> ().material.color;

		SetChildColors ();
	}
	

	void Update () {
/*		if (nationHostile) {
			LaunchWMDs ();
		}
*/
	}


	void OnCollisionEnter (Collision deb) {
		Color debColor = deb.gameObject.GetComponent<MeshRenderer>().material.color;
		if (debColor != natColor) {
			natHP = natHP - 5;
			if (natHP <= 0) {
				Emitter.GetComponent<PickupEmitter> ().nationList.Remove (gameObject);
				Destroy (gameObject);
			} else {
				foreach (SpriteRenderer sprite in childSprites) {
					Vector3 spriteScale = sprite.gameObject.transform.localScale;
					Vector3 spriteShrink = new Vector3 (-0.5f / 3.25f, -0.5f / 0.5f, -0.5f / 1.0f);

					if (debColor == sprite.color) {
						//print (natColor + " nation attacked by " + debColor + " nation");
						sprite.gameObject.transform.localScale += spriteShrink;

						if (sprite.gameObject.transform.localScale.y <= 0.0f) {
							//nationHostile = true;
							//LaunchWMDs ();
							foreach (var nation in gameObject.GetComponentInParent<NationParent>().nations) {
								if (nation.GetComponent<MeshRenderer> ().material.color == debColor) {
									print (gameObject.name + "launching WMD at " + nation);

									WMDClone = Instantiate (WMD, gameObject.transform.position + Vector3.up, Quaternion.identity);
									Rigidbody WMDRB = WMDClone.GetComponent<Rigidbody> ();

//Adding sideways velocity to WMDClone to attempt to "aim" it at the offending nation
									Vector3 WMDVel = new Vector3 ((nation.transform.position.x - gameObject.transform.position.x) * 1.5f, 80.0f, 0.0f);
									WMDRB.AddForce (WMDVel);
/* TODO Instead, maybe just shoot the WMDClone straight up (slightly sideways), into an off-screen collider, where it is destroyed.
A moment later, instantiate another WMD from a position above the "offending nation", falling down like the debris (maybe faster?)
*/
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
			WMDStrike ();
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
	}


	void LaunchWMDs () {
/*		foreach (var nation in gameObject.GetComponentInParent<NationParent>().nations) {
			if (nation.GetComponent<MeshRenderer>().material.color == ) {
				
			}
		}
*/
	}


	void WMDStrike () {
		natHP = natHP - 20; //Higher? Lower?
		if (natHP <= 0) {
			Emitter.GetComponent<PickupEmitter> ().nationList.Remove (gameObject);
			Destroy (gameObject);
		}
		print ("WMD strike on nation");
	}
}