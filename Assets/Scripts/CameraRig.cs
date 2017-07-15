using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRig : SingletonBehaviour<CameraRig> {

	public float smoothTime = 1;

	Transform target => Player.instance.transform;

	public Camera cam { get; private set; }

	Vector3 velocity;

	void Awake() {
		cam = GetComponent<Camera>();
	}

	void Update() {
		Vector3 position = transform.position;
		Vector3 targetPosition = target.position;
		targetPosition.z = position.z;
		position = Vector3.SmoothDamp(position, targetPosition, ref velocity, smoothTime);
		transform.position = position;
	}

}
