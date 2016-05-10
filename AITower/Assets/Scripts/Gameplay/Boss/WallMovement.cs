using UnityEngine;
using System.Collections;

public class WallMovement : MonoBehaviour {
	public Transform transform;
	public float start;
	public float end;
	public float singleTime = 10.0f;
	public float startAnimationTime = 0.0f;
	public int direction; // 0 - pos z, 1 - neg z, 2 - pos x, 3 - neg x
	public bool animating;
	private bool isStart = true;

	public void Reset() {
		if(direction == 0) {
			ResetPosZ();
		} else if(direction == 1) {
			ResetNegZ();
		} else if(direction == 2) {
			ResetPosX();
		} else if(direction == 3) {
			ResetNegX();
		}
		isStart = true;
		animating = false;
	}

	private void ResetPosZ() {
		transform.position = new Vector3(transform.position.x,transform.position.y,start);
	}

	private void ResetNegZ() {
		transform.position = new Vector3(transform.position.x,transform.position.y,start);
	}

	private void ResetPosX() {
		transform.position = new Vector3(start,transform.position.y,transform.position.z);
	}

	private void ResetNegX() {
		transform.position = new Vector3(start,transform.position.y,transform.position.z);
	}

	// Update is called once per frame
	void Update () {
		if(animating) {
			if(direction == 0) {
				UpdatePosZ();
			} else if(direction == 1) {
				UpdateNegZ();
			} else if(direction == 2) {
				UpdatePosX();
			} else if(direction == 3) {
				UpdateNegX();
			}
		}
	}

	private void UpdatePosZ() {
		float dt = (Time.time - startAnimationTime) / singleTime;
		if(Time.time - startAnimationTime >= singleTime) {
			if(isStart) {
				transform.position = new Vector3(transform.position.x,transform.position.y,end);
			} else {
				transform.position = new Vector3(transform.position.x,transform.position.y,start);
			}
			animating = false;
			isStart = !isStart;
		} else {
			if(isStart) {
				Vector3 newPos = new Vector3(transform.position.x,transform.position.y,(end-start)*dt+start);
				transform.position = newPos;
			} else {
				Vector3 newPos = new Vector3(transform.position.x,transform.position.y,end-(end-start)*dt);
				transform.position = newPos;
			}
		}
	}

	private void UpdateNegZ() {
		float dt = (Time.time - startAnimationTime) / singleTime;
		if(Time.time - startAnimationTime >= singleTime) {
			if(isStart) {
				transform.position = new Vector3(transform.position.x,transform.position.y,end);
			} else {
				transform.position = new Vector3(transform.position.x,transform.position.y,start);
			}
			animating = false;
			isStart = !isStart;
		} else {
			if(isStart) {
				Vector3 newPos = new Vector3(transform.position.x,transform.position.y,start-(start-end)*dt);
				transform.position = newPos;
			} else {
				Vector3 newPos = new Vector3(transform.position.x,transform.position.y,end+(start-end)*dt);
				transform.position = newPos;
			}
		}
	}

	private void UpdatePosX() {
		float dt = (Time.time - startAnimationTime) / singleTime;
		if(Time.time - startAnimationTime >= singleTime) {
			if(isStart) {
				transform.position = new Vector3(end,transform.position.y,transform.position.z);
			} else {
				transform.position = new Vector3(start,transform.position.y,transform.position.z);
			}
			animating = false;
			isStart = !isStart;
		} else {
			if(isStart) {
				Vector3 newPos = new Vector3((end-start)*dt+start,transform.position.y,transform.position.z);
				transform.position = newPos;
			} else {
				Vector3 newPos = new Vector3(end-(end-start)*dt,transform.position.y,transform.position.z);
				transform.position = newPos;
			}
		}
	}

	public bool ShouldStopAnimating() {
		return !animating;
	}

	private void UpdateNegX() {
		float dt = (Time.time - startAnimationTime) / singleTime;
		if(Time.time - startAnimationTime >= singleTime) {
			if(isStart) {
				transform.position = new Vector3(end,transform.position.y,transform.position.z);
			} else {
				transform.position = new Vector3(start,transform.position.y,transform.position.z);
			}
			animating = false;
			isStart = !isStart;
		} else {
			if(isStart) {
				Vector3 newPos = new Vector3(start-(start-end)*dt,transform.position.y,transform.position.z);
				transform.position = newPos;
			} else {
				Vector3 newPos = new Vector3(end+(start-end)*dt,transform.position.y,transform.position.z);
				transform.position = newPos;
			}
		}
	}
}
