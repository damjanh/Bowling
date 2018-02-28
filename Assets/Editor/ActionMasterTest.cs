using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

[TestFixture]
public class ActionMasterTest {

	private ActionMaster.Action endTurn = ActionMaster.Action.END_TURN;
	private ActionMaster.Action tidy = ActionMaster.Action.TIDY;
	private ActionMaster.Action reset = ActionMaster.Action.RESET;
	private ActionMaster.Action endGame = ActionMaster.Action.END_GAME;

	private ActionMaster actionMaster;

	[SetUp]
	public void Setup() {
		actionMaster = new ActionMaster();
	}

	[Test]
	public void T00_PassingTest () {
		Assert.AreEqual (1, 1);
	}

	[Test]
	public void T01_StrikeReturnsEndTurn() {
		Assert.AreEqual(endTurn, actionMaster.Bowl(10));
	}

	[Test]
	public void T02_Bowl8ReturnsTidy() {
		Assert.AreEqual(tidy, actionMaster.Bowl(8));
	}

	[Test]
	public void T03_Bowl28SpareReturnsEndtTurn() {
		actionMaster.Bowl(2);
		Assert.AreEqual(endTurn, actionMaster.Bowl(8));
	}

	[Test]
	public void T04_BowlStrikeInLastFrameReturnsReset() {
		int [] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
		foreach(int roll in rolls) {
			actionMaster.Bowl(roll);
		}
		Assert.AreEqual(reset, actionMaster.Bowl(10));
	}

	[Test]
	public void T05_BowlSpareInLasetFrameReturnsReset() {
		int [] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
		foreach(int roll in rolls) {
			actionMaster.Bowl(roll);
		}
		actionMaster.Bowl(5);
		Assert.AreEqual(reset, actionMaster.Bowl(5));
	}

	[Test]
	public void T06_GameEndSpareLastFrame() {
		int [] rolls = { 8, 2, 7, 3, 3, 4, 10, 2, 8, 10, 10, 8, 0, 10, 8, 2 };
		foreach(int roll in rolls) {
			actionMaster.Bowl(roll);
		}
		Assert.AreEqual(endGame, actionMaster.Bowl(9));
	}

	[Test]
	public void T07_GameEndsAtBowl20() {
		int [] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1};
		foreach(int roll in rolls) {
			actionMaster.Bowl(roll);
		}
		Assert.AreEqual(endGame, actionMaster.Bowl(1));
	}

	[Test]
	public void T08_LastFrameBowl10_1ReturnsReset() {
		int [] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10};
		foreach(int roll in rolls) {
			actionMaster.Bowl(roll);
		}
		Assert.AreEqual(tidy, actionMaster.Bowl(1));
	}

	[Test]
	public void T09_LastFrameBowl10_0ReturnsTidy() {
		int [] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10};
		foreach(int roll in rolls) {
			actionMaster.Bowl(roll);
		}
		Assert.AreEqual(tidy, actionMaster.Bowl(0));
	}

	[Test]
	public void T10_Bowl0_10_5_1ReturnEndTurn () {
		int[] rolls = {0, 10, 5};
		foreach(int roll in rolls) {
			actionMaster.Bowl(roll);
		}
		Assert.AreEqual (endTurn, actionMaster.Bowl(1));
	}

	[Test]
	public void T11_LastThreeFramesStrikeReturnsEndGame () {
		int[] rolls = {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 10};
		foreach(int roll in rolls) {
			actionMaster.Bowl(roll);
		}
		Assert.AreEqual (endGame, actionMaster.Bowl(10));
	}

	[Test]
	public void T12_Bowl0_1ReturnsEndTurn () {
		actionMaster.Bowl(0);
		Assert.AreEqual (endTurn, actionMaster.Bowl(1));
	}
}
