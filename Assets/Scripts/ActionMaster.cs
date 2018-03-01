using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMaster {

	public enum Action { TIDY, RESET, END_TURN, END_GAME };

	private int[] bowls = new int[21];
	private int bowlNumber = 1;

	public static Action NextAction(List<int> pinFalls) {
		ActionMaster actionMaster = new ActionMaster();
		Action currentAction = new Action();

		foreach(int pinFall in pinFalls) {
			currentAction = actionMaster.Bowl(pinFall);
		}

		return currentAction;
	}

	public Action Bowl (int pins) {
		if (pins < 0 || pins > 10) {throw new UnityException ("Invalid pins");}

		bowls [bowlNumber - 1] = pins;

		if (bowlNumber == 21) {
			return Action.END_GAME;
		}

		// Last-frame special cases
		if (bowlNumber >= 19 && pins == 10) {
			bowlNumber++;
			return Action.RESET;
		} else if (bowlNumber == 20) {
			bowlNumber++;
			if (bowls[18] == 10 && bowls[19] == 0) {
				return Action.TIDY;
			} else if (bowls[18] + bowls[19] == 10) {
				return Action.RESET;
			} else if (Bowl21Awarded()) {
				return Action.TIDY;
			} else {
				return Action.END_GAME;
			}
		}

		if (bowlNumber % 2 != 0) {
			// First frame
			if (pins == 10) {
				bowlNumber += 2;
				return Action.END_TURN;
			} else {
				bowlNumber ++;
				return Action.TIDY;
			}
		} else if (bowlNumber % 2 == 0) {
			// Second frame
			bowlNumber ++;
			return Action.END_TURN;
		}

		throw new UnityException ("Not sure what action to return!");
	}

	private bool Bowl21Awarded () {
		return (bowls [18] + bowls [19] >= 10);
	}
}
