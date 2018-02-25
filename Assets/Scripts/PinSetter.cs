using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

	private Pin[] pins;

	public Text standingPinsCountText;

	private bool isBallInBox = false;

	void Start () {
		pins = FindObjectsOfType<Pin>();

		standingPinsCountText.text = CountStatnding().ToString();
	}

	int CountStatnding() {
		int standing = 0;

		foreach(Pin pin in pins) {
			if (pin.IsStanding()) {
				standing ++;
			}
		}
		return standing;
	}

	void UpdateUI() {
		standingPinsCountText.color = isBallInBox ? Color.red : Color.black;
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.GetComponent<Ball>() != null) {
			isBallInBox = true;
			UpdateUI();
		}
	}

	void OnTriggerExit(Collider collider) {
		if(collider.gameObject.GetComponent<Ball>() != null) {
			isBallInBox = false;
			UpdateUI();
		} else if (collider.gameObject.transform.GetComponentInParent<Pin>() != null) {
			Destroy(collider.gameObject.transform.parent.gameObject);
		}
	}
}
