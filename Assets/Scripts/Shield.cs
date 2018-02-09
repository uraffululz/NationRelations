using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour {

	float moveSpeed = 5.0f;

	void Start () {
		
	}
	

	void Update () {
		Vector3 shieldPos = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z);

		if (Input.GetKey(KeyCode.LeftArrow)) {
			shieldPos = shieldPos + (Vector3.left * moveSpeed * Time.deltaTime);
		} else if (Input.GetKey(KeyCode.RightArrow)) {
			shieldPos = shieldPos + (Vector3.right * moveSpeed * Time.deltaTime);
		}

		shieldPos.x = Mathf.Clamp (shieldPos.x, 2.0f, 14.0f);
		this.transform.position = shieldPos;
	}
}
