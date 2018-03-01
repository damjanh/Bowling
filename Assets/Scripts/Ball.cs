using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	private Rigidbody thisRigidbody;

	private AudioSource audioSource;

	private Vector3 startPositon;

	// Flags if the ball has been launched.
	private bool isLaunched = false;

	void Start () {
		thisRigidbody = GetComponent<Rigidbody>();
		audioSource = GetComponent<AudioSource>();

		thisRigidbody.useGravity = false;
		startPositon = transform.position;
	}

	public void Launch(Vector3 launchVelocity) {
		isLaunched = true;

		thisRigidbody.useGravity = true;
		thisRigidbody.velocity = launchVelocity;

		audioSource.Play();
	}

	public bool IsLaunched() {
		return isLaunched;
	}

	public void Reset() {
		// Reset ball launched flag.
		isLaunched = false;
		// Reset ball to start position.
		transform.position = startPositon;
		// Reset ball rotation.
		transform.rotation = Quaternion.identity;
		// Set ball velocity to zero.
		thisRigidbody.angularVelocity = Vector3.zero;
		thisRigidbody.velocity = Vector3.zero;
		// Disable gravity until launch.
		thisRigidbody.useGravity = false;
	}
}
