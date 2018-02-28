using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Ball))]
public class BallDragLaunch : MonoBehaviour {

	private Ball ball;
	private float dragStartTime;
	private Vector3 dragStartPosition;

	void Start () {
		ball = GetComponent<Ball>();
	}
	
	public void DragStart() {
		dragStartTime = Time.time;
		dragStartPosition = Input.mousePosition;
	}

	public void DragEnd() {
		if (!ball.IsLaunched()) {
			Vector3 dragEndPosition = Input.mousePosition;
			float dragDuration = Time.time - dragStartTime;

			float launchSpeedX = (dragEndPosition.x - dragStartPosition.x) / dragDuration;
			float launchSpeedZ = (dragEndPosition.y - dragStartPosition.y) / dragDuration;

			ball.Launch(new Vector3(launchSpeedX, 0, launchSpeedZ));
		}
	}

	public void MoveStart(float amount) {
		if (!ball.IsLaunched() && ball.transform.position.x + amount >= -50 && ball.transform.position.x + amount <= 50) {
			ball.transform.Translate(new Vector3(amount, 0, 0));
		}
	}
}
