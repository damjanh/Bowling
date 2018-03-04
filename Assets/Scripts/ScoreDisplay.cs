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
		for(int i = 0; i < formattedOutput.Length; i++) {
			frameTexts[i].text = formattedOutput[i].ToString();
		}
	}

	public void FillFreames(List<int> frames) {
		for(int i = 0; i < frameTexts.Length; i++) {
			frameTexts[i].text = frames[i].ToString();
		}
	}

	public static string FormatRolls(List<int> rolls) {
		string formatted = "";
		for(int i = 0; i < rolls.Count; i++) {
			int rollNumber = formatted.Length + 1;
			if (rolls[i] == 0) {
				formatted += "-";
			} else if (rollNumber % 2 == 0 && rolls[i - 1] + rolls[i] == 10) {
				// Spare
				formatted += "/";
			} else if (rolls[i] == 10) {
				// Strike
				formatted += "X";
				if (rollNumber < 19 ) {
					formatted += " ";
				}
			} else {
				formatted += rolls[i].ToString();
			}
		}
		return formatted;
	}
}
