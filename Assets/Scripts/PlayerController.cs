using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float walkSpeed = 5;
	public float hammerSwingAcceleration = 100;
	public float jumpHeight = 1.5f;
	public float groundCheckDistance = 0.1f;
	public LayerMask groundLayers;

	public Player player { get; private set; }

	public Rigidbody2D body => player?.body;

	bool jumpRequested;

	CircleCollider2D circle;

	void Awake() {
		player = GetComponent<Player>();
		circle = GetComponent<CircleCollider2D>();
	}

	void Update() {
		if (!jumpRequested && Input.GetButtonDown("Jump")) {
			jumpRequested = true;
		}
	}

	void FixedUpdate() {
		Hammer hammer = player.hammer;
		if (hammer != null) {
			float torque = hammerSwingAcceleration * hammer.body.inertia;
			float hammerInput = Input.GetAxisRaw("Swing Hammer");
			hammer.body.AddTorque(- torque * hammerInput);
		}
		if (CheckGround()) {
			float walkInput = Input.GetAxisRaw("Walk");
			Vector2 velocity = body.velocity;
			velocity.x = 
			walkSpeed * walkInput;
			// Mathf.Lerp(velocity.x, walkSpeed * walkInput, Mathf.Abs(walkInput));
			if (jumpRequested) {
				velocity.y = Mathf.Sqrt(-2 * Physics2D.gravity.y * jumpHeight);
			}
			body.velocity = velocity;
		}
		jumpRequested = false;
	}

	bool CheckGround() {
		RaycastHit2D hit = Physics2D.CircleCast(
			body.position,
			circle.radius,
			Vector2.down,
			groundCheckDistance,
			groundLayers
		);
		return hit.collider != null;
	}

	void OnDrawGizmosSelected() {
		if (circle == null) {
			circle = GetComponent<CircleCollider2D>();
		}
		Gizmos.DrawWireSphere(transform.position + Vector3.down * groundCheckDistance, circle.radius);
	}


}
