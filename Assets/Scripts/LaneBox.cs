using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneBox : MonoBehaviour {

	private PinSetter pinSetter;

	void Start() {
		pinSetter = FindObjectOfType<PinSetter>();
	}

	void OnTriggerExit(Collider collider) {
		if (collider.gameObject.GetComponent<Ball>() != null) {
			pinSetter.BallOutOfPlay();
		}
	}
}
