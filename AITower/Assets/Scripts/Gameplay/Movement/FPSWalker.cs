using UnityEngine;
using System.Collections;

public class FPSWalker : MonoBehaviour {
	[SerializeField] private float speed = 2.0f;
	public float Speed
	{
		get { return speed; }
		set { speed = value; }
	}
	[SerializeField] private float stickToGroundForce = 10.0f; // Prevents player from falling through ground
	private CharacterController characterController;
	private MouseLook mouseLook;
	private Quaternion originalRotation;

	public void Start() {
		characterController = GetComponent<CharacterController>();
		mouseLook = GetComponentInChildren<MouseLook>();
		originalRotation = transform.localRotation;
	}

	void Update() {
		// Update the player's y rotation based on which direction
		// camera is facing
		Quaternion yRotation = mouseLook.UpdateRotation();
		transform.localRotation = originalRotation * yRotation;
	}

	public void FixedUpdate() {
		// Moves with arrow keys
		Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"),-stickToGroundForce,Input.GetAxis("Vertical"));

		// Move in terms on the player's local y rotation
		moveDirection = transform.TransformDirection(transform.localRotation * moveDirection);
		moveDirection *= speed;

		if (characterController)
		{
			characterController.Move(moveDirection * Time.fixedDeltaTime);
		}
	}
}