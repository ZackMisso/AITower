using UnityEngine;
using System.Collections;

public class ElevatorControl : MonoBehaviour {
	public PGSystem pgRef = null;
	public ElevatorControl otherElevator;
	public ElevatorDoorControl firstDoor;
	public ElevatorDoorControl secondDoor;
	public Transform playerTransform;
	public float endHeight = 100.0f;
	public bool entrance = false;
	private bool escalating = false;
	private Vector3 startPosition;

	void Start() {
		startPosition = gameObject.transform.position;
		if(pgRef == null) {
			Debug.Log("Error.. Elevator Control Needs Ref to PGSystem");
		}
	}

	public void StartFloor() {
		if(entrance) {
			firstDoor.Open();
			secondDoor.Open();
		}
	}

	// Update is called once per frame
	void Update () {
		if(transform.position.y >= endHeight) {
			escalating = false;
			pgRef.BeatLevel();
			pgRef.GenerateLevel();
			// move player and elevator back to start
			float diff = transform.position.y - startPosition.y;
			gameObject.transform.position = new Vector3(gameObject.transform.position.x,gameObject.transform.position.y - diff,gameObject.transform.position.z);
			playerTransform.position = new Vector3(playerTransform.position.x,playerTransform.position.y - diff,playerTransform.position.z);
			// open elevator
			firstDoor.Open();
			secondDoor.Open();
			// set the other elevator to be an entrance
			entrance = false;
			otherElevator.entrance = true;
			otherElevator.StartFloor();
		}
		if(escalating)
			transform.position = new Vector3(transform.position.x,transform.position.y+.05f,transform.position.z);
	}

	void OnTriggerEnter(Collider other) {
		if(entrance)
		{
  		if (other.gameObject.tag == "Player")
    	{
      	escalating = true;
				firstDoor.Close();
				secondDoor.Close();
    	}
		}
	}
}
