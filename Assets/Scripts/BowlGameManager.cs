using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlGameManager : MonoBehaviour {

	private List<int> bowls = new List<int>();

	private PinSetter pinSetter;
	private Ball ball;
	private ScoreDisplay scoreDisplay;

	void Start () {
		pinSetter = FindObjectOfType<PinSetter>();
		ball = FindObjectOfType<Ball>();
		scoreDisplay = FindObjectOfType<ScoreDisplay>();
	}
	
	public void Bowl(int pinFall) {
		// Add current pin fall cout to history of bowls.
		bowls.Add(pinFall);
		// Perform next action based on the current and previous bowl counts.
		pinSetter.PerformAction(ActionMaster.NextAction(bowls));
		// Update score dispaly.
	 	scoreDisplay.FillRollCard(bowls);
		scoreDisplay.FillFreames(ScoreMaster.ScoreCumulative(bowls));

		ball.Reset();
	}
}
