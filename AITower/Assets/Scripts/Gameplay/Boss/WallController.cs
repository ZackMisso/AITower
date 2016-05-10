using UnityEngine;
using System.Collections;

public class WallController : MonoBehaviour {
	public WallMovement front = null;
	public WallMovement back = null;
	public WallMovement left = null;
	public WallMovement right = null;
	public float initialDelay = 5.0f;
	private float startDelayTime = -1.0f;
	private WallMovement currentWall = null;
	private bool delaying = true;

	// Use this for initialization
	void Start () {
		if(front == null) {
			Debug.Log("Error.. Front Wall Must Not be Null");
		}
		if(back == null) {
			Debug.Log("Error.. Back Wall Must Not be Null");
		}
		if(left == null) {
			Debug.Log("Error.. Left Wall Must Not be Null");
		}
		if(right == null) {
			Debug.Log("Error.. Right Wall Must Not be Null");
		}
	}

	public void Reset() {
		front.Reset();
		back.Reset();
		left.Reset();
		right.Reset();
		startDelayTime = -1.0f;
		delaying = true;
		currentWall = null;
	}

	// Update is called once per frame
	void Update () {
		if(delaying && startDelayTime == -1.0f) {
			startDelayTime = Time.time;
		}
		if(delaying && Time.time - startDelayTime > initialDelay) {
			delaying = false;
		}
		if(!delaying) {
			if(currentWall == null) {
				int num = Random.Range(0,4);
				if(num==0) {
					currentWall = front;
				} else if(num == 1) {
					currentWall = back;
				} else if(num == 2) {
					currentWall = left;
				} else if(num == 3) {
					currentWall = right;
				}
				currentWall.startAnimationTime = Time.time;
				currentWall.animating = true;
			}
			if(currentWall.ShouldStopAnimating()) {
				currentWall = null;
			}
		}
	}
}
