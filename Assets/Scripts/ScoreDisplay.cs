using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

	public Text[] frameTexts;
	public Text[] bowlTexts;

	void Start () {
		foreach(Text roll in bowlTexts) {
			roll.text = "";
		}
		foreach(Text frame in frameTexts) {
			frame.text = "";
		}
	}
	
	public void FillRollCard(List<int> rolls) {
		string formattedOutput = FormatRolls(rolls);
		for(int i = 0; i < bowlTexts.Length; i++) {
			frameTexts[i].text = formattedOutput[i].ToString();
		}
	}

	public void FillFreames(List<int> frames) {
		for(int i = 0; i < frameTexts.Length; i++) {
			frameTexts[i].text = frames[i].ToString();
		}
	}

	public static string FormatRolls(List<int> rolls) {
		// TODO: Implement
		return "";
	}
}
