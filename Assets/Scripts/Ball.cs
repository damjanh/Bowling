using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	private Rigidbody thisRigidbody;

	private AudioSource audioSource;
	
	private bool isLaunched = false;

	void Start () {
		thisRigidbody = GetComponent<Rigidbody>();
		audioSource = GetComponent<AudioSource>();

		thisRigidbody.useGravity = false;
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
}
