using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	private Rigidbody thisRigidbody;

	private AudioSource audioSource;
	
	private bool isLaunched = false;

	private Vector3 startPositon;

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
		isLaunched = false;
		transform.position = startPositon;
		thisRigidbody.useGravity = false;
		thisRigidbody.angularVelocity = Vector3.zero;
		thisRigidbody.velocity = Vector3.zero;
	}
}
