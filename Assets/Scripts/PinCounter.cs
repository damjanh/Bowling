using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinCounter : MonoBehaviour {

	// Time in seconds we allow the pins to settle after ball was in pin box.
	private static float SETTLE_TIME = 4f;

	public Text standingPinsCountText;

	private BowlGameManager gameManager;

	private int lastStandingCount = -1; // -1 Default state.
	private int lastSettledCount = 10;
	private float lastChangeTime;

	private State state = State.IDLE;

	// Use this for initialization
	void Start () {
		gameManager = FindObjectOfType<BowlGameManager>();
	}

	void Update() {
		// No need to update while the ball is far away from pins.
		if (state == State.BALL_IN_BOX) {
			UpdateUI(state);
			CheckStandingAfterBallTrigger();
		}
	}

	public void setState(State state) {
		this.state = state;
	}

	public void UpdateUI(State state) {
		standingPinsCountText.text = CountStatnding().ToString();
		switch (state) {
			case State.IDLE:
				standingPinsCountText.color = Color.black;
				break;
			case State.BALL_IN_BOX:
				standingPinsCountText.color = Color.red;
				break;
			case State.SETTLED:
				standingPinsCountText.color = Color.green;
				break;
		}
	}

	public void Reset() {
		lastSettledCount = 10;
	}

	int CountStatnding() {
		int standing = 0;

		Pin[] pins = FindObjectsOfType<Pin>();
		foreach(Pin pin in pins) {
			if (pin.IsStanding()) {
				standing ++;
			}
		}
		return standing;
	}

	public void CheckStandingAfterBallTrigger() {
		int currentStanding = CountStatnding();

		if (currentStanding != lastStandingCount) {
			lastChangeTime = Time.time;
			lastStandingCount = currentStanding;
			return;
		} 

		if (Time.time - lastChangeTime > SETTLE_TIME) {
			PinsHaveSettled();
		}
	}

	private void PinsHaveSettled() {
		state = State.SETTLED;
		int pinFall = lastSettledCount - lastStandingCount;
		lastSettledCount = lastStandingCount;
		lastStandingCount = 0;
		lastChangeTime = 0;

		state = State.IDLE;
		gameManager.Bowl(pinFall);
		UpdateUI(state);
	}

	void OnTriggerExit(Collider collider) {
		if (collider.gameObject.GetComponent<Ball>() != null) {
			state = State.BALL_IN_BOX;
		}
	}
}