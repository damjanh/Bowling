using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

	private static float SETTLE_TIME = 4f;

	public Text standingPinsCountText;

	private int lastStandingCount = -1; // -1 Default state.

	private int lastSettledCount = 10;

	public GameObject pinsReset;

	private float lastChangeTime;

	private Ball ball;

	private ActionMaster actionMaster = new ActionMaster();

	private Animator animator;

	private enum State {
		IDLE, BALL_IN_BOX, SETTLED
	}

	private State state = State.IDLE;

	void Start () {
		ball = FindObjectOfType<Ball>();
		animator = GetComponent<Animator>();
		UpdateUI(CountStatnding().ToString(), state);
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

	void Update() {
		// No need to update while the ball is far away from pins.
		if (state == State.BALL_IN_BOX) {
			UpdateUI(CountStatnding().ToString(), state);
			CheckStanding();
		}
	}

	void UpdateUI(string text, State state) {
		standingPinsCountText.text = text;
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

	void CheckStanding() {
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

	public void RaisePins() {
		foreach(Pin pin in FindObjectsOfType<Pin>()) {
			pin.Raise();	
		}
	}

	public void LowerPins() {
		foreach(Pin pin in FindObjectsOfType<Pin>()) {
			pin.Lower();
		}
	}

	public void RenewPins() {
		Instantiate(pinsReset, new Vector3(0, 0, 1829), Quaternion.identity);
	}

	void PinsHaveSettled() {
		int pinFall = lastSettledCount - lastStandingCount;
		lastSettledCount = lastStandingCount;
		switch(actionMaster.Bowl(pinFall)) {
			case ActionMaster.Action.TIDY:
				animator.SetTrigger("tidyTrigger");
			break;
			case ActionMaster.Action.RESET:
				animator.SetTrigger("resetTrigger");
				lastSettledCount = 10;
			break;
			case ActionMaster.Action.END_TURN:
				animator.SetTrigger("resetTrigger");
			break;
			case ActionMaster.Action.END_GAME:
				// No logic yet.
			break;
		}

		state = State.SETTLED;
		UpdateUI(lastStandingCount.ToString(), state);

		ball.Reset();
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.GetComponent<Ball>() != null) {
			state = State.BALL_IN_BOX;
		}
	}

	void OnTriggerExit(Collider collider) {
		if (collider.gameObject.transform.GetComponentInParent<Pin>() != null) {
			Destroy(collider.gameObject.transform.parent.gameObject);
		}
	}
}
