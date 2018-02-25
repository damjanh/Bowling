using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

	private Pin[] pins;

	public Text standingPinsCountText;

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
}
