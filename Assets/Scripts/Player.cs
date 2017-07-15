using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : SingletonBehaviour<Player> {

	public Hammer startingHammer;

	public Hammer hammer { get; private set; }

	public Rigidbody2D body { get; private set; }

	void Awake() {
		body = GetComponent<Rigidbody2D>();
	}
	
	void Start() {
		if (startingHammer != null) {
			EquipHammer(startingHammer);
		}
	}

	public void EquipHammer(Hammer hammer) {
		UnequipHammer();
		if (hammer != null) {
			this.hammer = hammer;
			hammer.joint.connectedBody = body;
		}
	}

	public void UnequipHammer() {
		if (hammer != null) {
			hammer.joint.connectedBody = null;
		}
	}

}
