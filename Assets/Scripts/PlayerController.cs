using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float moveSpeed = 5.0F;
	public float rotationSpeed = 300.0F;
	public float rotationInterval;
	private Vector3 moveDirection = Vector3.zero;
	private CharacterController controller;
	private Quaternion destRotation;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController> ();
		destRotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		moveDirection = transform.TransformDirection (moveDirection);
		moveDirection = moveDirection * moveSpeed;
		controller.SimpleMove (moveDirection);

		if (Input.GetKey (KeyCode.Q)) {
			destRotation.eulerAngles = destRotation.eulerAngles - new Vector3 (0, rotationInterval, 0);
		}

		if (Input.GetKey (KeyCode.E)) {
			destRotation.eulerAngles = destRotation.eulerAngles + new Vector3 (0, rotationInterval, 0);
		}

		float step = rotationSpeed * Time.deltaTime;
		transform.rotation = Quaternion.RotateTowards (transform.rotation, destRotation, step);
	}
}
