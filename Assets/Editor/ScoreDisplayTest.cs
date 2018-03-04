using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using System.Linq;

[TestFixture]
public class ScoreDisplayTest {

	[Test]
	public void T00_PassingTest() {
		Assert.AreEqual (1, 1);
	}

	[Test]
	public void T01_Bowl1() {
		int[] bowls = { 1 };
		string formatted = "1";
		Assert.AreEqual(formatted, ScoreDisplay.FormatRolls(bowls.ToList()));
	}

	[Test]
	public void T02_Bowl6() {
		int[] bowls = { 2 };
		string formatted = "2";
		Assert.AreEqual(formatted, ScoreDisplay.FormatRolls(bowls.ToList()));
	}

	[Test]
	public void T03_Bowl34() {
		int[] bowls = { 3, 4 };
		string formatted = "34";
		Assert.AreEqual(formatted, ScoreDisplay.FormatRolls(bowls.ToList()));
	}

	[Test]
	public void T04_Bowl91() {
		int[] bowls = { 9, 1 };
		string formatted = "9/";
		Assert.AreEqual(formatted, ScoreDisplay.FormatRolls(bowls.ToList()));
	}

	[Test]
	public void T05_BowlX() {
		int[] bowls = { 10 };
		string formatted = "X ";
		Assert.AreEqual(formatted, ScoreDisplay.FormatRolls(bowls.ToList()));
	}

	[Test]
	public void T06_Bowl191() {
		int[] bowls = { 1, 9, 1 };
		string formatted = "1/1";
		Assert.AreEqual(formatted, ScoreDisplay.FormatRolls(bowls.ToList()));
	}

	[Test]
	public void T07_SpareInLastFrame() {
		int[] bowls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 9, 5 };
		string formatted = "1111111111111111111/5";
		Assert.AreEqual(formatted, ScoreDisplay.FormatRolls(bowls.ToList()));
	}

	[Test]
	public void T08_StrikeInLastFrame() {
		int[] bowls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 1, 1 };
		string formatted = "111111111111111111X11";
		Assert.AreEqual(formatted, ScoreDisplay.FormatRolls(bowls.ToList()));
	}

	[Test]
	public void T09_Bowl0() {
		int[] bowls = { 0 };
		string formatted = "-";
		Assert.AreEqual(formatted, ScoreDisplay.FormatRolls(bowls.ToList()));
	}
	
	[Test]
	public void T10_MultipleStrikes() {
		int[] bowls = { 10, 10, 10 };
		string formatted = "X X X ";
		Assert.AreEqual(formatted, ScoreDisplay.FormatRolls(bowls.ToList()));
	}

	[Test]
	public void T11_AllStrikes() {
		int[] bowls = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
		string formatted = "X X X X X X X X X XXX";
		Assert.AreEqual(formatted, ScoreDisplay.FormatRolls(bowls.ToList()));
	}

	[Test]
	public void T10_MultipleSpares() {
		int[] bowls = { 1, 9, 2, 8, 3, 7, 4, 6, 5, 5, 6, 4 };
		string formatted = "1/2/3/4/5/6/";
		Assert.AreEqual(formatted, ScoreDisplay.FormatRolls(bowls.ToList()));
	}

}
