using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreMaster  {

	public static List<int> ScoreFrames(List<int> rolls) {
		List<int> frames = new List<int>();
		for (int i = 1; i < rolls.Count; i += 2) {
			if (frames.Count == 10) {
				// Only 11 frames exist.
				break;
			}	

			if (rolls[i - 1] + rolls[i] < 10) {				
				frames.Add (rolls [i - 1] + rolls [i]);
			}

			if (i >= rolls.Count - 1) {
				break;
			}

			if (rolls[i - 1] == 10) {							
				i--; // Strike - one bowl.										
				frames.Add (10 + rolls [i + 1] + rolls[i + 2]);
			} else if (rolls[i - 1] + rolls[i] == 10) {	
				// Spare	
				frames.Add (10 + rolls [i + 1]);
			}
		}
		return frames;
	}

	public static List<int> ScoreCumulative(List<int> rolls) {
		List<int> cumulativeScores = new List<int>();
		int total = 0;

		foreach(int frameScore in ScoreFrames(rolls)) {
			total += frameScore;
			cumulativeScores.Add(total);
		}

		return cumulativeScores;
	}
}
