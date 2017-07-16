using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour {

	public Transform centerOfMass;
	public float minHitSpeed;	// the minimum angular speed the hammer needs to be moving at to hit things

	public Rigidbody2D body { get; private set; }
	public HingeJoint2D joint { get; private set; }

	void Awake() {
		body = GetComponent<Rigidbody2D>();
		joint = GetComponent<HingeJoint2D>();
		if (centerOfMass != null) {
			body.centerOfMass = transform.InverseTransformPoint(centerOfMass.position);
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		
	}

}
