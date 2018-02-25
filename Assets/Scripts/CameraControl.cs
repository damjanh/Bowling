using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	private static float headpinPos = 1829f;

	public Ball ball;

	private Vector3 offset;

	void Start () {
		offset = transform.position - ball.transform.position;
	}

	void Update () {
		if (transform.position.z < headpinPos) {
			transform.position = ball.transform.position + offset;
		}
	}
}
