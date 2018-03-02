using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using System.Linq;

[TestFixture]
public class ScoreDisplayTest {

	[Test]
	public void T00_PassingTest () {
		Assert.AreEqual (1, 1);
	}

	[Test]
	public void T01_Bowl1 () {
		int[] bowls = { 1 };
		string formatted = "1";
		Assert.AreEqual(formatted, ScoreDisplay.FormatRolls(bowls.ToList()));
	}
}
