using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHammerController : MonoBehaviour {

	public Player player { get; private set; }

	public float angularVelocityFactor = 5;

	// public float angularAcceleration = 30;

	bool swingRequested;

	void Awake() {
		player = GetComponent<Player>();
	}

	void Update() {
		if (!swingRequested && Input.GetButtonDown("Fire1")) {
			swingRequested = true;
		}
	}
	void FixedUpdate() {
		Hammer hammer = player.hammer;
		if (hammer != null) {
			if (swingRequested) {
				swingRequested = false;
				Vector2 input = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
				Vector2 hammerDirection = hammer.transform.right;
				float angle = Vector2.SignedAngle(hammerDirection, input);
				hammer.body.angularVelocity = angle * angularVelocityFactor;
			}
			// TAKE 2
			// float torque = angularAcceleration * hammer.body.inertia;
			// float input = Input.GetAxisRaw("Horizontal");
			// hammer.body.AddTorque(- torque * input);

			// TAKE 1
			// Vector2 input = new Vector2(
			// 	Input.GetAxis("Horizontal"),
			// 	Input.GetAxis("Vertical")
			// );
			// Vector2 hammerDirection = hammer.transform.right;
			// hammer.body.angularVelocity = Mathf.Lerp(hammer.body.angularVelocity, (Vector2.SignedAngle(hammerDirection, input) / Time.fixedDeltaTime), input.magnitude);
		}
	}

}
