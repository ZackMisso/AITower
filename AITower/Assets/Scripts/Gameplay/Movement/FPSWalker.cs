using UnityEngine;
using System.Collections;

public class FPSWalker : MonoBehaviour {
	public float speed = 2.0f;
	public float initialJumpVelocity = 3.0f;
	public float stickToGroundForce = -1.0f; // Prevents player from falling through ground
	private float currentYVelocity = 0.0f;
	private bool canJump = true;
	private float prevHeight = 0.0f;

	private CharacterController characterController;
	private MouseLook mouseLook;
	private Quaternion originalRotation;
	private Rigidbody rigidBody;

	public void Start() {
		characterController = GetComponent<CharacterController>();
		mouseLook = GetComponentInChildren<MouseLook>();
		rigidBody = GetComponent<Rigidbody>();
		originalRotation = transform.localRotation;
	}

	void Update() {
		// Update the player's y rotation based on which direction
		// camera is facing
		Quaternion yRotation = mouseLook.UpdateRotation();
		transform.localRotation = originalRotation * yRotation;
	}

	public void FixedUpdate() {
		if(prevHeight == gameObject.transform.position.y && currentYVelocity < 0.0f) {
			canJump = true;
		}
		prevHeight = gameObject.transform.position.y;
		currentYVelocity += stickToGroundForce*Time.fixedDeltaTime;
		//Debug.Log(currentYVelocity);
		if(currentYVelocity < -10.0f) {
			currentYVelocity = -10.0f;
		}
		// Moves with arrow keys
		Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"),currentYVelocity,Input.GetAxis("Vertical"));
		if (Input.GetKeyDown("space") && canJump) {
			currentYVelocity = initialJumpVelocity;
			canJump = false;
		}
		// Move in terms on the player's local y rotation
		moveDirection = transform.TransformDirection(transform.localRotation * moveDirection);
		moveDirection *= speed;

		if (characterController)
		{
			characterController.Move(moveDirection * Time.fixedDeltaTime);
		}
	}
}
