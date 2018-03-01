using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinSetter : MonoBehaviour {

	public GameObject pinsReset;
	private Animator animator;
	private PinCounter pinCounter;

	private State state = State.IDLE;

	void Start () {
		animator = GetComponent<Animator>();

		pinCounter = FindObjectOfType<PinCounter>();
		pinCounter.UpdateUI(state);
	}

	void Update() {
		// No need to update while the ball is far away from pins.
		if (state == State.BALL_IN_BOX) {
			pinCounter.UpdateUI(state);
			pinCounter.CheckStandingAfterBallTrigger();
		}
	}

	public void PerformAction(ActionMaster.Action action) {
			switch(action) {
				case ActionMaster.Action.TIDY:
					animator.SetTrigger("tidyTrigger");
					break;
				case ActionMaster.Action.RESET:
					animator.SetTrigger("resetTrigger");
					pinCounter.Reset();
					break;
				case ActionMaster.Action.END_TURN:
					animator.SetTrigger("resetTrigger");
					pinCounter.Reset();
					break;
				case ActionMaster.Action.END_GAME:
					// No logic yet.
					break;
				default:
					break;
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

	public void SetState(State state) {
		this.state = state;
	}

	void OnTriggerExit(Collider collider) {
		if (collider.gameObject.transform.GetComponentInParent<Pin>() != null) {
			Destroy(collider.gameObject.transform.parent.gameObject);
		}
	}
}
