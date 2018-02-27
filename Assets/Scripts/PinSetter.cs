using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

	public Text standingPinsCountText;

	private bool isBallInBox = false;

	private int nextUpdate = 1;

	void Start () {
		UpdateUI(CountStatnding().ToString());
	}

	int CountStatnding() {
		int standing = 0;

		Pin[] pins = FindObjectsOfType<Pin>();
		foreach(Pin pin in pins) {
			if (pin.IsStanding()) {
				standing ++;
			}
		}
		return standing;
	}

	void Update() {
		UpdateUI(CountStatnding().ToString());
	}

	void UpdateUI(string text) {
		standingPinsCountText.text = text;
		standingPinsCountText.color = isBallInBox ? Color.red : Color.black;
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.GetComponent<Ball>() != null) {
			isBallInBox = true;
		}
	}

	void OnTriggerExit(Collider collider) {
		if(collider.gameObject.GetComponent<Ball>() != null) {
			isBallInBox = false;
		} else if (collider.gameObject.transform.GetComponentInParent<Pin>() != null) {
			Destroy(collider.gameObject.transform.parent.gameObject);
		}
	}
}
