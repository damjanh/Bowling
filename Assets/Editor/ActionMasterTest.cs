using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using System.Linq;

[TestFixture]
public class ActionMasterTest {

	private ActionMaster.Action endTurn = ActionMaster.Action.END_TURN;
	private ActionMaster.Action tidy = ActionMaster.Action.TIDY;
	private ActionMaster.Action reset = ActionMaster.Action.RESET;
	private ActionMaster.Action endGame = ActionMaster.Action.END_GAME;

	[SetUp]
	public void Setup() {
		// Just here to remind me.
	}

	[Test]
	public void T00_PassingTest () {
		Assert.AreEqual (1, 1);
	}

	[Test]
	public void T01_StrikeReturnsEndTurn() {
		int[] rolls = { 10 };
		Assert.AreEqual(endTurn, ActionMaster.NextAction(rolls.ToList()));
	}

	[Test]
	public void T02_Bowl8ReturnsTidy() {
		int[] rolls = { 8 };
		Assert.AreEqual(tidy, ActionMaster.NextAction(rolls.ToList()));
	}

	[Test]
	public void T03_Bowl28SpareReturnsEndtTurn() {
		int[] rolls = { 8, 2 };
		Assert.AreEqual(endTurn, ActionMaster.NextAction(rolls.ToList()));
	}

	[Test]
	public void T04_BowlStrikeInLastFrameReturnsReset() {
		int [] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10 };
		Assert.AreEqual(reset, ActionMaster.NextAction(rolls.ToList()));
	}

	[Test]
	public void T05_BowlSpareInLasetFrameReturnsReset() {
		int [] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 5, 5 };
		Assert.AreEqual(reset, ActionMaster.NextAction(rolls.ToList()));
	}

	[Test]
	public void T06_GameEndSpareLastFrame() {
		int [] rolls = { 8, 2, 7, 3, 3, 4, 10, 2, 8, 10, 10, 8, 0, 10, 8, 2 ,9 };
		Assert.AreEqual(endGame, ActionMaster.NextAction(rolls.ToList()));
	}

	[Test]
	public void T07_GameEndsAtBowl20() {
		int [] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
		Assert.AreEqual(endGame, ActionMaster.NextAction(rolls.ToList()));
	}

	[Test]
	public void T08_LastFrameBowl10_1ReturnsReset() {
		int [] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 1 };
		Assert.AreEqual(tidy, ActionMaster.NextAction(rolls.ToList()));
	}

	[Test]
	public void T09_LastFrameBowl10_0ReturnsTidy() {
		int [] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 0 };
		Assert.AreEqual(tidy, ActionMaster.NextAction(rolls.ToList()));
	}

	[Test]
	public void T10_Bowl0_10_5_1ReturnEndTurn () {
		int[] rolls = { 0, 10, 5, 1 };
		Assert.AreEqual (endTurn, ActionMaster.NextAction(rolls.ToList()));
	}

	[Test]
	public void T11_LastThreeFramesStrikeReturnsEndGame () {
		int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 10, 10 };
		Assert.AreEqual (endGame, ActionMaster.NextAction(rolls.ToList()));
	}

	[Test]
	public void T12_Bowl0_1ReturnsEndTurn () {
		int[] rolls = { 0, 1 };
		Assert.AreEqual (endTurn, ActionMaster.NextAction(rolls.ToList()));
	}
}
