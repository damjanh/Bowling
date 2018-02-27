using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

	public float distanceToRaise = 30;

	public float standingThreshold = 3f;

	private Rigidbody thisRigidbody;

	void Start() {
		thisRigidbody = GetComponent<Rigidbody>();
	}


	public bool IsStanding() {
		float tiltX = Mathf.Abs(transform.rotation.eulerAngles.x);
		float tiltZ = Mathf.Abs(transform.rotation.eulerAngles.z);
	
		return (tiltX < standingThreshold  || tiltX > 360 - standingThreshold) && (tiltZ < standingThreshold || tiltZ > 360 - standingThreshold);
	}

	public void Raise() {
		print("raise");
		if (IsStanding()) {
			print("raise");
			thisRigidbody.useGravity = false;
			transform.Translate(new Vector3(0, distanceToRaise, 0), Space.World);
		}
	}

	public void Lower() {
		transform.Translate(new Vector3(0, -distanceToRaise, 0), Space.World);
		thisRigidbody.useGravity = true;
	}

	public void Renwe() {

	}

}
