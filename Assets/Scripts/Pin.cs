using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

	public bool isStanding;

	public float standingThreshold = 3f;

	void Updte() {
		isStanding = IsStanding();
	}

	public bool IsStanding() {
		float tiltX = Mathf.Abs(transform.rotation.eulerAngles.x);
		float tiltZ = Mathf.Abs(transform.rotation.eulerAngles.z);
	
		return (tiltX < standingThreshold  || tiltX > 360 - standingThreshold) && (tiltZ < standingThreshold || tiltZ > 360 - standingThreshold);
	}
}
