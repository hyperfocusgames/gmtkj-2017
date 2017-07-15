using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHammerController : MonoBehaviour {

	public Player player { get; private set; }

	public float angularAcceleration = 30;

	void Awake() {
		player = GetComponent<Player>();
	}

	void FixedUpdate() {
		Hammer hammer = player.hammer;
		if (hammer != null) {
			

			// TAKE 2
			float torque = angularAcceleration * hammer.body.inertia;
			float input = Input.GetAxisRaw("Horizontal");
			hammer.body.AddTorque(- torque * input);

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
