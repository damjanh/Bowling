using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	private Rigidbody thisRigidbody;

	private AudioSource audioSource;

	public float launchSpeed;

	void Start () {
		thisRigidbody = GetComponent<Rigidbody>();
		audioSource = GetComponent<AudioSource>();

		Launch();
	}

	public void Launch() {
		thisRigidbody.velocity = new Vector3(0, 0, launchSpeed);
		audioSource.Play();
	}
}
