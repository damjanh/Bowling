using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	private Rigidbody thisRigidbody;

	private AudioSource audioSource;

	public Vector3 launchVelocity;

	void Start () {
		thisRigidbody = GetComponent<Rigidbody>();
		audioSource = GetComponent<AudioSource>();

		Launch();
	}

	public void Launch() {
		thisRigidbody.velocity = launchVelocity;
		audioSource.Play();
	}
}
