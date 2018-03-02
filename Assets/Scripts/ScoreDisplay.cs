using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

	public Text[] rollTexts;
	public Text[] frameTexts;

	void Start () {
		foreach(Text roll in rollTexts) {
			roll.text = "";
		}
		foreach(Text frame in frameTexts) {
			frame.text = "";
		}
	}
	
	public void FillRollCard(List<int> rolls) {
		
	}
}
