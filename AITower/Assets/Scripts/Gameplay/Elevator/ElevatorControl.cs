using UnityEngine;
using System.Collections;

// TODO :: MAKE THIS TIME BASED

public class ElevatorControl : MonoBehaviour {
	public ElevatorDoorControl firstDoor;
	public ElevatorDoorControl secondDoor;
	public float endHeight = 100.0f;
	private bool escalating = false;

	// Update is called once per frame
	void Update () {
		if(transform.position.y >= endHeight) {
			escalating = false;
			// testing elevator open
			firstDoor.Open();
			secondDoor.Open();
		}
		if(escalating)
			transform.position = new Vector3(transform.position.x,transform.position.y+.05f,transform.position.z);
	}

	void OnTriggerEnter(Collider other) {
  	if (other.gameObject.tag == "Player")
    {
      escalating = true;
			firstDoor.Close();
			secondDoor.Close();
    }
	}
}
